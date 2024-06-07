using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using Antelcat.WinAPI.IOCTL.Structs;

// ReSharper disable InconsistentNaming

namespace Antelcat.WinAPI.IOCTL;

public static class DeviceIOControl
{
    public static void Run()
    {
        var ex = GetDriveLayoutInformationEx(PhysicalDrivePrefix + "0");
    }

    public static IDriveLayoutInformationEx GetDriveLayoutInformationEx(string plFileName)
    {
        var hDevice = CreateFile(
            plFileName,
            0x80000000,
            (uint)FileShare.ReadWrite,
            IntPtr.Zero,
            (uint)FileMode.Open,
            0,
            IntPtr.Zero);

        if (hDevice == IntPtr.Zero) throw new Win32Exception(Marshal.GetLastWin32Error(), "Create File error");

        try
        {
            uint bytesReturned = 0;
            var driveLayoutSize = Marshal.SizeOf<DRIVE_LAYOUT_INFORMATION_EX>() +
                                  128 * Marshal.SizeOf<PARTITION_INFORMATION_EX>();
            var driveLayoutBuffer = Marshal.AllocHGlobal(driveLayoutSize);
            var success = DeviceIoControl(
                hDevice,
                IOCTL_DISK_GET_DRIVE_LAYOUT_EX,
                IntPtr.Zero,
                0,
                driveLayoutBuffer,
                (uint)driveLayoutSize,
                ref bytesReturned,
                IntPtr.Zero);

            if (success)
            {
                var driveLayout = Marshal.PtrToStructure<DRIVE_LAYOUT_INFORMATION_EX>(driveLayoutBuffer);
                Marshal.FreeHGlobal(driveLayoutBuffer);
                return driveLayout;
            }
            else
            {
                var error = Marshal.GetLastWin32Error();
                if (error is 6) throw new UnauthorizedAccessException("Device IO should be run as administrator");
                else throw new Win32Exception(error, "Device io control error");
            }
        }
        finally
        {
            CloseHandle(hDevice);
        }
    }

    #region Defines

    // 磁盘设备路径
    private const string PhysicalDrivePrefix = @"\\.\PhysicalDrive";

    #endregion
}
