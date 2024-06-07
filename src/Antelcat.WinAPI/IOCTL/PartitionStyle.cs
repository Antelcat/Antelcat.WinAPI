namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// PARTITION_STYLE 枚举枚举的驱动器上的分区样式
/// </summary>
public enum PartitionStyle
{
    /// <summary>
    /// 主启动记录 (MBR) 格式
    /// </summary>
    PARTITION_STYLE_MBR,

    /// <summary>
    /// GUID 分区表 (GPT) 格式
    /// </summary>
    PARTITION_STYLE_GPT,

    /// <summary>
    /// 分区未采用两种已识别格式（MBR 或 GPT）格式化
    /// </summary>
    PARTITION_STYLE_RAW
}