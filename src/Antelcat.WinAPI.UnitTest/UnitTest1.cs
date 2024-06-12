using System.Management;
using System.Runtime.Versioning;
using Antelcat.WinAPI.Extensions;
using Antelcat.WinAPI.IOCTL;

namespace Antelcat.WinAPI.UnitTest;

[SupportedOSPlatform("windows")]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestDataPartition()
    {
        var info = IOCTL.Interop.GetDriveLayoutInformationEx(0);
        if (info.PartitionStyle is not PartitionStyle.PARTITION_STYLE_GPT) Assert.Fail();
        var dataPartition = info.PartitionEntry
            .Where(static x => x.PartitionStyle == PartitionStyle.PARTITION_STYLE_GPT
                               && x.PartitionInformation.Gpt.Is(PartitionTypes.PARTITION_BASIC_DATA_GUID))
            .Select(static x => x.PartitionInformation.Gpt.PartitionId)
            .ToArray();
    }

    [Test]
    public void TestDisk()
    {
        var discs = SetupAPI.Interop.EnumDiskInfo().ToArray();
    }

    private IEnumerable<(int,Guid[])> PartitionsWithIndex() =>
        IOCTLExtension.EnumAllDriveLayoutInformationEx()
            .Select(static (x, s) => (s, x.PartitionEntry
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
                }).ToArray()));

    [Test]
    public void TestAllDataPartitions()
    {
        var partitions = PartitionsWithIndex().ToArray();
        Console.WriteLine(string.Join("\n", partitions.Select(x => x.Item2.ToString())));
        Assert.That(partitions, Is.Not.Empty);
    }

    [Test]
    public void TestBitLocker()
    {
        var path = new ManagementPath(@"\ROOT\CIMV2\Security\MicrosoftVolumeEncryption")
        {
            ClassName = "Win32_EncryptableVolume"
        };
        var scope = new ManagementScope(path);
        path.Server = Environment.MachineName;
        var objectSearcher = new ManagementClass(scope, path, new ObjectGetOptions());
        foreach (var item in objectSearcher.GetInstances())
        {
            Console.WriteLine($"{item["DriveLetter"]} {item["DeviceID"]} {item["ProtectionStatus"]} {item["ConversionStatus"]}");
        } 
    }

    [Test]
    public void TestDevice()
    {
        var discs = new ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition")
            .Get()
            .Cast<ManagementObject>()
            .ToArray();
        var logics = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk")
            .Get()
            .Cast<ManagementObject>()
            .ToArray();
        var arr = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
            .Get()
            .Cast<ManagementObject>()
            .ToArray();
        var ids = discs.Select(x => x["PartitionID"]).ToArray();
        var parts = arr.Select(x => x["SerialNumber"]).ToArray();
        var log   = logics.Select(x => x["VolumeSerialNumber"]).ToArray();
    }

    [Test]
    public void TestCurrentDisk()
    {
        var root = Path.GetPathRoot(AppContext.BaseDirectory);
        Assert.That(root, Is.Not.Null);
        var disk = FileAPI.Interop.GetVolumeName(root);
        Assert.That(disk, Is.Not.Null);
        var number = Interop.GetDeviceNumber($@"\\.\{root[..^1]}");
        var guid   = Guid.Parse(disk.AsSpan(@"\\?\Volume{".Length, 36));
        var arr = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
            .Get()
            .Cast<ManagementObject>();
        var index = PartitionsWithIndex().FirstOrDefault(x => x.Item2.Contains(guid)).Item1;
    }

    [Test]
    public void TestGetDeviceNumber()
    {
        var number = Interop.GetDeviceNumber(@"\\.\H:");
    }
}