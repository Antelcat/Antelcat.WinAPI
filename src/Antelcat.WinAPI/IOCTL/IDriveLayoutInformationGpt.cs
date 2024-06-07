using System;

namespace Antelcat.WinAPI.IOCTL;

public interface IDriveLayoutInformationGpt
{
    Guid DiskId               { get; }
    long StartingUsableOffset { get; }
    long UsableLength         { get; }
    uint MaxPartitionCount    { get; }
}