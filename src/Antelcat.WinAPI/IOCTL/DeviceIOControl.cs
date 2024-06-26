﻿using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using Antelcat.WinAPI.IOCTL.Structs;
using Antelcat.WinAPI.Native;

// ReSharper disable InconsistentNaming

namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// <see cref="Kernel32"/>
/// </summary>
static partial class Interop
{
    /// <summary>
    /// IOCTL_DISK_GET_DRIVE_LAYOUT_EX
    /// </summary>
    /// <param name="diskNumber">number of Physical drive</param>
    /// <returns></returns>
    public static IDriveLayoutInformationEx GetDriveLayoutInformationEx(int diskNumber) =>
        GetDriveLayoutInformationEx(PhysicalDrivePrefix + diskNumber);

    /// <summary>
    /// IOCTL_DISK_GET_DRIVE_LAYOUT_EX
    /// </summary>
    /// <param name="plFileName"></param>
    /// <returns></returns>
    /// <exception cref="Win32Exception"></exception>
    /// <exception cref="UnauthorizedAccessException"></exception>
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

        if (hDevice.IsInvalid) throw new Win32Exception(Marshal.GetLastWin32Error(), "Create File error");

        try
        {
            uint bytesReturned = 0;
            var driveLayoutSize = Marshal.SizeOf<DRIVE_LAYOUT_INFORMATION_EX>() +
                                  128 * Marshal.SizeOf<PARTITION_INFORMATION_EX>();
            var driveLayoutBuffer = Marshal.AllocHGlobal(driveLayoutSize);
            var success = DeviceIoControl(
                hDevice.DangerousGetHandle(),
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
           hDevice.Close();
        }
    }

    /// <summary>
    /// <see cref="IOCTL_STORAGE_GET_DEVICE_NUMBER"/>
    /// </summary>
    /// <param name="volume"></param>
    public static IStorageDeviceNumber GetDeviceNumber(string volume)
    {
        var volumeHandle = CreateFile(
            volume,
            0x80000000,
            (uint)FileShare.ReadWrite,
            IntPtr.Zero,
            (uint)FileMode.Open,
            0,
            IntPtr.Zero);
        if (volumeHandle.IsInvalid) throw new Win32Exception(Marshal.GetLastWin32Error(), "Create File error");

        try
        {
            uint bytesReturned = 0;
            var  size          = Marshal.SizeOf<STORAGE_DEVICE_NUMBER>();
            var  buffer        = Marshal.AllocHGlobal(size);
            var success = DeviceIoControl(
                volumeHandle.DangerousGetHandle(),
                IOCTL_STORAGE_GET_DEVICE_NUMBER,
                IntPtr.Zero,
                0,
                buffer,
                (uint)size,
                ref bytesReturned,
                IntPtr.Zero);

            if (success)
            {
                var deviceNumber = Marshal.PtrToStructure<STORAGE_DEVICE_NUMBER>(buffer);
                Marshal.FreeHGlobal(buffer);
                return deviceNumber;
            }

            var error = Marshal.GetLastWin32Error();
            if (error is 6) throw new UnauthorizedAccessException("Device IO should be run as administrator");
            throw new Win32Exception(error, "Device io control error");
        }
        finally
        {
            volumeHandle.Close();
        }
    }
}
