using System;
using Antelcat.WinAPI.Native;

namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// 包含特定于主启动记录 (MBR) 磁盘的分区信息
/// </summary>
public interface IPartitionInformationMbr
{
    /// <summary>
    /// 分区的类型。 有关值的列表，请参阅 磁盘分区类型
    /// </summary>
    byte  PartitionType       { get; }
    
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
}