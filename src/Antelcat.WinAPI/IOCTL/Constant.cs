using System;

namespace Antelcat.WinAPI.IOCTL;

public static partial class Interop
{
    /// <summary>
    /// IOCTL_DISK_GET_DRIVE_LAYOUT_EX
    /// </summary>
    public const uint IOCTL_DISK_GET_DRIVE_LAYOUT_EX = 0x00070050;
    
    /// <summary>
    /// IOCTL_STORAGE_GET_DEVICE_NUMBER
    /// </summary>
    public const uint IOCTL_STORAGE_GET_DEVICE_NUMBER = 0x002D1080;
    
    internal const string PhysicalDrivePrefix             = @"\\.\PhysicalDrive";

}