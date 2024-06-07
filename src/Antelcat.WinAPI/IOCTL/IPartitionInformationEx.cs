namespace Antelcat.WinAPI.IOCTL;

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
    bool                          IsServicePartition   { get; }
    
    /// <summary>
    /// <see cref="IPartitionInformationGpt"/> 或 <see cref="IPartitionInformationMbr"/>
    /// </summary>
    IPartitionInformationMbrOrGpt PartitionInformation { get; }
}