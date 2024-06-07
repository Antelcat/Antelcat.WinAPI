namespace Antelcat.WinAPI.IOCTL;

public interface IDriveLayoutInformationMbr
{
    uint Signature { get; }
    uint CheckSum  { get; }
}