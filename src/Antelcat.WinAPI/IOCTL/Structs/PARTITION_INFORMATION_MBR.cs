using System;
using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct PARTITION_INFORMATION_MBR : IPartitionInformationMbr
{
    public byte  partitionType;
    public bool  bootIndicator;
    public bool  recognizedPartition;
    public ulong hiddenSectors;
    public Guid  partitionId;
    
    public byte  PartitionType       => partitionType;
    public bool  BootIndicator       => bootIndicator;
    public bool  RecognizedPartition => recognizedPartition;
    public ulong HiddenSectors       => hiddenSectors;
    public Guid  PartitionId         => partitionId;
}