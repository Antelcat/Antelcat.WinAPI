using System.Linq;
using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct DRIVE_LAYOUT_INFORMATION_EX : IDriveLayoutInformationEx
{
    internal uint                           partitionStyle;
    internal uint                           partitionCount;
    internal DRIVE_LAYOUT_INFORMATION_UNION driveLayoutUnion;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    internal PARTITION_INFORMATION_EX[] partitionEntry;

    public PartitionStyle                  PartitionStyle         => (PartitionStyle)partitionStyle;
    public int                             PartitionCount         => (int)partitionCount;
    public IDriveLayoutInformationMbrOrGpt DriveLayoutInformation => driveLayoutUnion;

    public IPartitionInformationEx[] PartitionEntry =>
        partitionEntry
            .Take(PartitionCount)
            .Select(static x => (IPartitionInformationEx)x)
            .ToArray();
}