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
        IPartitionInformationGpt.Constant.EFIDefinedGuids.TryGetValue(gpt.PartitionType, out var name) ? name : null;
}