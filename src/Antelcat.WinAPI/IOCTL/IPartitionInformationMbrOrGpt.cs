namespace Antelcat.WinAPI.IOCTL;

public interface IPartitionInformationMbrOrGpt
{
    /// <summary>
    /// 一种PARTITION_INFORMATION_MBR结构，指定特定于主启动记录 (MBR) 磁盘的分区信息。 MBR 分区格式是标准 AT 样式 格式。
    /// </summary>
    IPartitionInformationMbr Mbr { get; }
    
    /// <summary>
    /// 一种PARTITION_INFORMATION_GPT结构，指定特定于 GUID 分区表的分区信息 (GPT) 磁盘。 GPT 格式对应于 EFI 分区格式。
    /// </summary>
    IPartitionInformationGpt Gpt { get; }
}