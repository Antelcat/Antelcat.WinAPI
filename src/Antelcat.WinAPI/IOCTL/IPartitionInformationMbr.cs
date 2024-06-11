using System;

namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// 包含特定于主启动记录 (MBR) 磁盘的分区信息
/// </summary>
public interface IPartitionInformationMbr
{
    /// <summary>
    /// 分区的类型。 有关值的列表，请参阅 磁盘分区类型
    /// </summary>
    PartitionTypes  PartitionType       { get; }
    
    /// <summary>
    /// 如果该成员为 <value>true</value>，则分区为启动分区。 当此结构与 IOCTL_DISK_SET_PARTITION_INFO_EX 控件代码一起使用时，将忽略此参数的值
    /// </summary>
    bool  BootIndicator       { get; }
    
    /// <summary>
    /// 如果此成员为 TRUE，则分区属于可识别的类型。 当此结构与 IOCTL_DISK_SET_PARTITION_INFO_EX 控件代码一起使用时，将忽略此参数的值。
    /// </summary>
    bool  RecognizedPartition { get; }
    
    /// <summary>
    /// 创建分区表时要分配的隐藏扇区数
    /// </summary>
    ulong HiddenSectors       { get; }
    
    /// <summary>
    /// 
    /// </summary>
    Guid  PartitionId         { get; }


    /// <summary>
    /// 标识了磁盘驱动程序使用的有效分区类型
    /// </summary>
    [Flags]
    public enum PartitionTypes
    {
        /// <summary>
        /// 未使用的条目分区
        /// </summary>
        PARTITION_ENTRY_UNUSED = 0x00,

        /// <summary>
        /// 扩展分区。
        /// </summary>
        PARTITION_EXTENDED = 0x05,

        /// <summary>
        /// FAT12 文件系统分区
        /// </summary>
        PARTITION_FAT_12 = 0x01,

        /// <summary>
        /// FAT16 文件系统分区
        /// </summary>
        PARTITION_FAT_16 = 0x04,

        /// <summary>
        /// FAT32 文件系统分区
        /// </summary>
        PARTITION_FAT32 = 0x0B,

        /// <summary>
        /// IFS 分区
        /// </summary>
        PARTITION_IFS = 0x07,

        /// <summary>
        /// (LDM) 分区的逻辑磁盘管理器
        /// </summary>
        PARTITION_LDM = 0x42,

        /// <summary>
        /// NTFT 分区
        /// </summary>
        PARTITION_NTFT = 0x80,

        /// <summary>
        /// 有效的 NTFT 分区
        /// 分区类型代码的高位表示分区是 NTFT 镜像或条带数组的一部分
        /// </summary>
        VALID_NTFT = 0xC0,
    }
}