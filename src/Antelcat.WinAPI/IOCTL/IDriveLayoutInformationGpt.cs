using System;

namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// 包含有关驱动器的 GUID 分区表 (GPT) 分区的信息
/// </summary>
public interface IDriveLayoutInformationGpt
{
    /// <summary>
    /// 磁盘的 GUID
    /// </summary>
    Guid DiskId { get; }

    /// <summary>
    /// 第一个可用块的起始字节偏移量
    /// </summary>
    long StartingUsableOffset { get; }

    /// <summary>
    /// 磁盘上可用块的大小（以字节为单位）
    /// </summary>
    long UsableLength { get; }

    /// <summary>
    /// 可在可用块中定义的最大分区数
    /// </summary>
    uint MaxPartitionCount { get; }
}