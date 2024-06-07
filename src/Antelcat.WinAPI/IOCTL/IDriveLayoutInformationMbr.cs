namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// 提供有关驱动器的主启动记录 (MBR) 分区的信息
/// </summary>
public interface IDriveLayoutInformationMbr
{
    /// <summary>
    /// 驱动器的签名
    /// </summary>
    uint Signature { get; }
    
    /// <summary>
    /// 
    /// </summary>
    uint CheckSum  { get; }
}