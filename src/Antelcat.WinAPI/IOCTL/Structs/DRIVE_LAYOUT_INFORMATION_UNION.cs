using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Explicit)]
internal struct DRIVE_LAYOUT_INFORMATION_UNION : IDriveLayoutInformationMbrOrGpt
{
    [FieldOffset(0)] public DRIVE_LAYOUT_INFORMATION_MBR mbr;
    [FieldOffset(0)] public DRIVE_LAYOUT_INFORMATION_GPT gpt;
    
    public                  IDriveLayoutInformationMbr   Mbr => mbr;
    public                  IDriveLayoutInformationGpt   Gpt => gpt;
}