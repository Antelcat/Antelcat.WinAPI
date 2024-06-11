using System.Diagnostics;
using Antelcat.WinAPI.Extensions;
using Antelcat.WinAPI.IOCTL;
using Antelcat.WinAPI.SetupAPI;

namespace Antelcat.WinAPI.UnitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestDataPartition()
    {
        var info = DeviceIOControl.GetDriveLayoutInformationEx(0);
        if(info.PartitionStyle is not PartitionStyle.PARTITION_STYLE_GPT) Assert.Fail();
        var dataPartition = info.PartitionEntry
            .Where(static x => x.PartitionStyle == PartitionStyle.PARTITION_STYLE_GPT
                               && x.PartitionInformation.Gpt.Is(PartitionTypes.PARTITION_BASIC_DATA_GUID))
            .Select(static x => x.PartitionInformation.Gpt.PartitionId)
            .ToArray();
    }

    [Test]
    public void TestDisk()
    {
        var discs = SetupDiGetClassDevs.SetupDiEnumDevicesInfo().ToArray();
    }

    [Test]
    public void TestAllDataPartitions()
    {
        var partitions = IOCTLExtension.EnumAllDriveLayoutInformationEx()
            .SelectMany(static x => x.PartitionEntry
                .Where(static x => x.PartitionStyle switch
                {
                    PartitionStyle.PARTITION_STYLE_GPT =>
                        x.PartitionInformation.Gpt.Is(PartitionTypes.PARTITION_BASIC_DATA_GUID),
                    PartitionStyle.PARTITION_STYLE_MBR =>
                        x.PartitionInformation.Mbr.PartitionType ==
                        IPartitionInformationMbr.PartitionTypes.PARTITION_IFS,
                    _ => false,
                })
                .Select(static x => x.PartitionStyle switch
                {
                    PartitionStyle.PARTITION_STYLE_GPT => x.PartitionInformation.Gpt.PartitionId,
                    PartitionStyle.PARTITION_STYLE_MBR => x.PartitionInformation.Mbr.PartitionId,
                    _                                  => Guid.Empty,
                }))
            .ToArray();
        Console.WriteLine(string.Join("\n" ,partitions.Select(x=>x.ToString())));
        Assert.That(partitions, Is.Not.Empty);
    }
}