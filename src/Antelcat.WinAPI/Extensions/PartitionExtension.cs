using Antelcat.WinAPI.IOCTL;

namespace Antelcat.WinAPI.Extensions;

public static class PartitionExtension
{
    public static string? PartitionTypeName(this IPartitionInformationGpt gpt) =>
        IPartitionInformationGpt.Constant.EFIDefinedGuids.TryGetValue(gpt.PartitionType, out var name) ? name : null;
}