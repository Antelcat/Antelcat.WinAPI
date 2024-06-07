using System;
using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.Native;

internal static class Kernel32
{
    public const uint IOCTL_DISK_GET_DRIVE_LAYOUT_EX   = 0x00070050;
    public const uint FILE_SHARE_READ                  = 0x00000001;
    public const uint FILE_SHARE_WRITE                 = 0x00000002;
    public const uint OPEN_EXISTING                    = 3;
    public const uint GENERIC_READ                     = 0x80000000;
    public const uint IOCTL_DISK_GET_PARTITION_INFO_EX = 0x00070048;
    
    
    internal const string kernel32 = "kernel32.dll";

    [DllImport(kernel32, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    [DllImport(kernel32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeviceIoControl(
        IntPtr hDevice,
        uint dwIoControlCode,
        IntPtr lpInBuffer,
        uint nInBufferSize,
        IntPtr lpOutBuffer,
        uint nOutBufferSize,
        ref uint lpBytesReturned,
        IntPtr lpOverlapped);

    [DllImport(kernel32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);
}