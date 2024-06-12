using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Antelcat.WinAPI.FileAPI;

/// <summary>
/// 
/// </summary>
public static class Interop
{
    private const int Prefer = 50;
    
    /// <summary>
    /// 获取 GUID 格式的磁盘信息
    /// </summary>
    /// <param name="volumeMountPoint"></param>
    /// <returns></returns>
    public static string? GetVolumeName(string volumeMountPoint)
    {
        var sb  = new StringBuilder(Prefer);
        return !GetVolumeNameForVolumeMountPoint(volumeMountPoint, sb, Prefer) ? null : sb.ToString();
    }

    /// <summary>
    /// 枚举所有的卷名和对应的 <see cref="GetVolumeName"/>
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<(string drive,string? volumeName)> EnumVolumeNames()
    {
        foreach (var drive in DriveInfo.GetDrives()) yield return (drive.Name, GetVolumeName(drive.Name));
    }
}