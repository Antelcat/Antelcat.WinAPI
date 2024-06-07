using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct PARTITION_INFORMATION_EX : IPartitionInformationEx
{
    internal byte                        partitionStyle;
    internal ulong                       startingOffset;
    internal ulong                       partitionLength;
    internal uint                        partitionNumber;
    internal char                        rewritePartition;
    internal char                        isServicePartition;
    internal PARTITION_INFORMATION_UNION partitionUnion;

    public PartitionStyle                PartitionStyle       => (PartitionStyle)partitionStyle;
    public ulong                         StartingOffset       => startingOffset;
    public ulong                         PartitionLength      => partitionLength;
    public uint                          PartitionNumber      => partitionNumber;
    public bool                          RewritePartition     => rewritePartition is (char)1;
    public bool                          IsServicePartition   => isServicePartition is (char)1;
    public IPartitionInformationMbrOrGpt PartitionInformation => partitionUnion;
}