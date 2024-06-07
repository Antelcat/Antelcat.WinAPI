using System;

namespace Antelcat.WinAPI.IOCTL;

public interface IPartitionInformationMbr
{
    byte  PartitionType       { get; }
    bool  BootIndicator       { get; }
    bool  RecognizedPartition { get; }
    ulong HiddenSectors       { get; }
    Guid  PartitionId         { get; }
}