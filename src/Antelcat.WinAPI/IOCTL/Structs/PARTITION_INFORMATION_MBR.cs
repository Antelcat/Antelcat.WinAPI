using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
[DebuggerDisplay("{PartitionId}")]
internal struct PARTITION_INFORMATION_MBR : IPartitionInformationMbr
{
    public                               byte partitionType;
    [MarshalAs(UnmanagedType.U1)] public bool bootIndicator;
    [MarshalAs(UnmanagedType.U1)] public bool recognizedPartition;
    public                               uint hiddenSectors;
    public                               Guid partitionId;

    public IPartitionInformationMbr.PartitionTypes PartitionType =>
        (IPartitionInformationMbr.PartitionTypes)partitionType;

    public bool BootIndicator       => bootIndicator;
    public bool RecognizedPartition => recognizedPartition;
    public uint HiddenSectors       => hiddenSectors;
    public Guid PartitionId         => partitionId;
}