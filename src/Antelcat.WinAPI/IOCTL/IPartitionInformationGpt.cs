using System;
using System.Collections.Generic;

namespace Antelcat.WinAPI.IOCTL;

public interface IPartitionInformationGpt
{
    /// <summary>
    /// 标识分区类型的 GUID
    /// EFI 规范支持的每个分区类型都由其自己的 GUID 标识，该 GUID 由分区的开发人员发布。
    /// <see cref="IPartitionInformationGpt.Constant"/>
    /// </summary>
    Guid   PartitionType { get; }
    
    /// <summary>
    /// 分区的 GUID
    /// </summary>
    Guid   PartitionId   { get; }
    
    /// <summary>
    /// 可扩展固件接口 (EFI) 分区的属性。
    /// 此成员可以是以下一个或多个值。
    /// </summary>
    ulong   Attributes    { get; }
    string Name          { get; }

    /// <summary>
    /// EFI常量
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// 由 Windows 创建和识别的数据分区类型。
        /// 只有此类型的分区可以分配驱动器号、接收卷 GUID 路径、主机装载的文件夹 (也称为卷装入点) ，并通过调用 FindFirstVolume 和 FindNextVolume 进行枚举。
        /// 此值只能为基本磁盘设置，但有一个例外。 如果为随后转换为动态磁盘的基本磁盘上的分区设置了 PARTITION_BASIC_DATA_GUID 和 GPT_ATTRIBUTE_PLATFORM_REQUIRED ，则分区仍将是基本分区，即使该磁盘的其余部分是动态磁盘。 这是因为分区被视为 GPT 磁盘上的 OEM 分区。
        /// </summary>
        public static readonly Guid PARTITION_BASIC_DATA_GUID = Guid.Parse("ebd0a0a2-b9e5-4433-87c0-68b6b72699c7");

        /// <summary>
        /// 没有分区。
        /// 可以为基本磁盘和动态磁盘设置此值。
        /// </summary>
        public static readonly Guid PARTITION_ENTRY_UNUSED_GUID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        /// <summary>
        /// 该分区是 EFI 系统分区。
        /// 可以为基本磁盘和动态磁盘设置此值。
        /// </summary>
        public static readonly Guid PARTITION_SYSTEM_GUID = Guid.Parse("c12a7328-f81f-11d2-ba4b-00a0c93ec93b");

        /// <summary>
        /// 该分区是 Microsoft 保留分区。
        /// 可以为基本磁盘和动态磁盘设置此值。
        /// </summary>
        public static readonly Guid PARTITION_MSFT_RESERVED_GUID = Guid.Parse("e3c9e316-0b5c-4db8-817d-f92df00215ae");

        /// <summary>
        /// 该分区是动态磁盘上 (LDM) 元数据分区的逻辑磁盘管理器。
        /// 只能为动态磁盘设置此值。
        /// </summary>
        public static readonly Guid PARTITION_LDM_METADATA_GUID = Guid.Parse("5808c8aa-7e8f-42e0-85d2-e1e90434cfb3");

        /// <summary>
        /// 该分区是动态磁盘上的 LDM 数据分区。
        /// 只能为动态磁盘设置此值。
        /// </summary>
        public static readonly Guid PARTITION_LDM_DATA_GUID = Guid.Parse("af9b60a0-1431-4f62-bc68-3311714a69ad");

        /// <summary>
        /// 该分区是 Microsoft 恢复分区。
        /// 可以为基本磁盘和动态磁盘设置此值。
        /// </summary>
        public static readonly Guid PARTITION_MSFT_RECOVERY_GUID = Guid.Parse("de94bba4-06d1-4d40-a16a-bfd50179d6ac");

        public static readonly Dictionary<Guid, string> EFIDefinedGuids = new()
        {
            { PARTITION_BASIC_DATA_GUID, nameof(PARTITION_BASIC_DATA_GUID) },
            { PARTITION_ENTRY_UNUSED_GUID, nameof(PARTITION_ENTRY_UNUSED_GUID) },
            { PARTITION_SYSTEM_GUID, nameof(PARTITION_SYSTEM_GUID) },
            { PARTITION_MSFT_RESERVED_GUID, nameof(PARTITION_MSFT_RESERVED_GUID) },
            { PARTITION_LDM_METADATA_GUID, nameof(PARTITION_LDM_METADATA_GUID) },
            { PARTITION_LDM_DATA_GUID, nameof(PARTITION_LDM_DATA_GUID) },
            { PARTITION_MSFT_RECOVERY_GUID, nameof(PARTITION_MSFT_RECOVERY_GUID) },
        };
    }
}