namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// 包含标准 AT 样式的主启动记录 (MBR) 和可扩展固件接口 (EFI) 磁盘的分区信息
/// </summary>
public interface IPartitionInformationEx
{
    /// <summary>
    /// 分区的格式。 有关值列表，请参阅 <see cref="PartitionStyle"/>
    /// </summary>
    PartitionStyle                PartitionStyle       { get; }
    
    /// <summary>
    /// 分区的起始偏移量
    /// </summary>
    ulong                         StartingOffset       { get; }
    
    /// <summary>
    /// 分区的大小（以字节为单位）。
    /// </summary>
    ulong                         PartitionLength      { get; }
    
    /// <summary>
    /// 分区数 (从 1 开始的) 。
    /// </summary>
    uint                          PartitionNumber      { get; }
    
    /// <summary>
    /// 如果此成员为 <value>true</value>，则分区可重写。 此参数的值应设置为 <value>true</value>。
    /// </summary>
    bool                          RewritePartition     { get; }
    
    /// <summary>
    /// 
    /// </summary>
    bool                          IsServicePartition   { get; }
    
    /// <summary>
    /// <see cref="IPartitionInformationGpt"/> 或 <see cref="IPartitionInformationMbr"/>
    /// </summary>
    IPartitionInformationMbrOrGpt PartitionInformation { get; }
}