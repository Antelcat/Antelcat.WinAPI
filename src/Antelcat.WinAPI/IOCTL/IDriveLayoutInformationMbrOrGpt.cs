namespace Antelcat.WinAPI.IOCTL;

public interface IDriveLayoutInformationMbrOrGpt
{
    IDriveLayoutInformationMbr Mbr { get; }
    IDriveLayoutInformationGpt Gpt { get; }
}