namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// 包含有关驱动器分区的扩展信息
/// </summary>
public interface IDriveLayoutInformationEx
{
    /// <summary>
    /// PARTITION_STYLE 枚举枚举的驱动器上的分区样式。
    /// </summary>
    PartitionStyle PartitionStyle { get; }

    /// <summary>
    /// 驱动器上的分区数。 在具有 MBR 布局的硬盘上，此值始终为 4 的倍数。 实际未使用的任何分区的分区类型都将PARTITION_ENTRY_UNUSED (0) 在此结构的 PartitionEntry 成员的 PARTITION_INFORMATION_EX 结构的 Mbr 成员的 PARTITION_INFORMATION_MBR 结构的 PartitionType 成员中设置。
    /// </summary>
    int PartitionCount { get; }

    /// <summary>
    /// 包含有关驱动器上主启动记录类型分区的信息的 <see cref="IDriveLayoutInformationMbr"/> 或
    /// <see cref="IDriveLayoutInformationGpt"/> 结构
    /// </summary>
    IDriveLayoutInformationMbrOrGpt DriveLayoutInformation { get; }

    /// <summary>
    /// <see cref="IPartitionInformationEx"/> 结构的可变大小数组，驱动器上的每个分区对应一个结构。
    /// </summary>
    IPartitionInformationEx[] PartitionEntry { get; }
}