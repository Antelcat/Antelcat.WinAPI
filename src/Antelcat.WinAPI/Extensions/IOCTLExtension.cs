using System.Collections.Generic;
using System.Linq;
using Antelcat.WinAPI.IOCTL;

namespace Antelcat.WinAPI.Extensions;

/// <summary>
/// <see cref="IOCTL"/> 的扩展
/// </summary>
public static class IOCTLExtension
{
    /// <summary>
    /// 枚举所有磁盘的分区信息
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<IDriveLayoutInformationEx> EnumAllDriveLayoutInformationEx()
        => Enumerable.Range(0, SetupAPI.Interop.EnumDiskInfo().ToArray().Length)
            .Select(Interop.GetDriveLayoutInformationEx);
}