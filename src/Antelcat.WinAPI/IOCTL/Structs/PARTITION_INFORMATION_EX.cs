using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct PARTITION_INFORMATION_EX : IPartitionInformationEx
{
    internal byte                        partitionStyle;
    internal ulong                       startingOffset;
    internal ulong                       partitionLength;
    internal uint                        partitionNumber;
    [MarshalAs(UnmanagedType.U1)]
    internal bool                        rewritePartition;
    [MarshalAs(UnmanagedType.U1)]
    internal bool                        isServicePartition;
    internal PARTITION_INFORMATION_UNION partitionUnion;

    public PartitionStyle                PartitionStyle       => (PartitionStyle)partitionStyle;
    public ulong                         StartingOffset       => startingOffset;
    public ulong                         PartitionLength      => partitionLength;
    public uint                          PartitionNumber      => partitionNumber;
    public bool                          RewritePartition     => rewritePartition ;
    public bool                          IsServicePartition   => isServicePartition;
    public IPartitionInformationMbrOrGpt PartitionInformation => partitionUnion;
}