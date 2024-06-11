using Antelcat.WinAPI.IOCTL;

namespace Antelcat.WinAPI.Extensions;

/// <summary>
/// <see cref="IPartitionInformationEx"/>相关扩展
/// </summary>
public static class PartitionExtension
{
    /// <summary>
    /// 获取 <see cref="IPartitionInformationGpt"/> 分区类型名
    /// </summary>
    /// <param name="gpt"></param>
    /// <returns></returns>
    public static string? PartitionTypeName(this IPartitionInformationGpt gpt) =>
        IPartitionInformationGpt.PartitionTypes.EFIDefinedGuids.TryGetValue(gpt.PartitionType, out var name) ? name : null;

    /// <summary>
    /// 判断是否是指定类型
    /// </summary>
    /// <param name="gpt"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool Is(this IPartitionInformationGpt gpt, PartitionTypes type) =>
        type switch
        {
            PartitionTypes.PARTITION_BASIC_DATA_GUID
                => gpt.PartitionType == IPartitionInformationGpt.PartitionTypes.PARTITION_BASIC_DATA_GUID,
            PartitionTypes.PARTITION_ENTRY_UNUSED_GUID
                => gpt.PartitionType == IPartitionInformationGpt.PartitionTypes.PARTITION_ENTRY_UNUSED_GUID,
            PartitionTypes.PARTITION_SYSTEM_GUID
                => gpt.PartitionType == IPartitionInformationGpt.PartitionTypes.PARTITION_SYSTEM_GUID,
            PartitionTypes.PARTITION_MSFT_RESERVED_GUID
                => gpt.PartitionType == IPartitionInformationGpt.PartitionTypes.PARTITION_MSFT_RESERVED_GUID,
            PartitionTypes.PARTITION_LDM_METADATA_GUID
                => gpt.PartitionType == IPartitionInformationGpt.PartitionTypes.PARTITION_LDM_METADATA_GUID,
            PartitionTypes.PARTITION_LDM_DATA_GUID
                => gpt.PartitionType == IPartitionInformationGpt.PartitionTypes.PARTITION_LDM_DATA_GUID,
            PartitionTypes.PARTITION_MSFT_RECOVERY_GUID
                => gpt.PartitionType == IPartitionInformationGpt.PartitionTypes.PARTITION_MSFT_RECOVERY_GUID,
            _ => false
        };
}

/// <summary>
/// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes"/>
/// </summary>
public enum PartitionTypes
{
    /// <summary>
    /// <see cref="IPartitionInformationGpt.PartitionTypes.PARTITION_BASIC_DATA_GUID"/>
    /// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes.PARTITION_BASIC_DATA_GUID"/>
    /// </summary>
    PARTITION_BASIC_DATA_GUID,
    /// <summary>
    /// <see cref="IPartitionInformationGpt.PartitionTypes.PARTITION_ENTRY_UNUSED_GUID"/>
    /// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes.PARTITION_ENTRY_UNUSED_GUID"/>
    /// </summary>
    PARTITION_ENTRY_UNUSED_GUID,
    /// <summary>
    /// <see cref="IPartitionInformationGpt.PartitionTypes.PARTITION_SYSTEM_GUID"/>
    /// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes.PARTITION_SYSTEM_GUID"/>
    /// </summary>
    PARTITION_SYSTEM_GUID,
    /// <summary>
    /// <see cref="IPartitionInformationGpt.PartitionTypes.PARTITION_MSFT_RESERVED_GUID"/>
    /// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes.PARTITION_MSFT_RESERVED_GUID"/>
    /// </summary>
    PARTITION_MSFT_RESERVED_GUID,
    /// <summary>
    /// <see cref="IPartitionInformationGpt.PartitionTypes.PARTITION_LDM_METADATA_GUID"/>
    /// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes.PARTITION_LDM_METADATA_GUID"/>
    /// </summary>
    PARTITION_LDM_METADATA_GUID,
    /// <summary>
    /// <see cref="IPartitionInformationGpt.PartitionTypes.PARTITION_LDM_DATA_GUID"/>
    /// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes.PARTITION_LDM_DATA_GUID"/>
    /// </summary>
    PARTITION_LDM_DATA_GUID,
    /// <summary>
    /// <see cref="IPartitionInformationGpt.PartitionTypes.PARTITION_MSFT_RECOVERY_GUID"/>
    /// <inheritdoc cref="IPartitionInformationGpt.PartitionTypes.PARTITION_MSFT_RECOVERY_GUID"/>
    /// </summary>
    PARTITION_MSFT_RECOVERY_GUID
}