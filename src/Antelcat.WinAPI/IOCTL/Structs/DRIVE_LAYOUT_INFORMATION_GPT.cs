using System;
using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct DRIVE_LAYOUT_INFORMATION_GPT : IDriveLayoutInformationGpt
{
    public Guid diskId;
    public long startingUsableOffset;
    public long usableLength;
    public uint maxPartitionCount;
    
    public Guid DiskId               => diskId;
    public long StartingUsableOffset => startingUsableOffset;
    public long UsableLength         => usableLength;
    public uint MaxPartitionCount    => maxPartitionCount;
}