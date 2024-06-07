using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct DRIVE_LAYOUT_INFORMATION_MBR : IDriveLayoutInformationMbr
{
    public uint signature;
    public uint checkSum;

    public uint Signature => signature;
    public uint CheckSum  => checkSum;
}