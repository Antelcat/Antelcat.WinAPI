namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// Union
/// </summary>
public interface IDriveLayoutInformationMbrOrGpt
{
    /// <summary>
    /// <see cref="IDriveLayoutInformationMbr"/>
    /// </summary>
    IDriveLayoutInformationMbr Mbr { get; }
    
    /// <summary>
    /// <see cref="IDriveLayoutInformationGpt"/>
    /// </summary>
    IDriveLayoutInformationGpt Gpt { get; }
}