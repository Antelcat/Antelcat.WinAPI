using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Antelcat.WinAPI.Native;

internal static class Kernel32
{
    internal const string kernel32 = "kernel32.dll";

    internal class Win32SafeHandle() : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid(true)
    {
        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
    
    [DllImport(kernel32, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern Win32SafeHandle CreateFile(
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
    private static extern bool CloseHandle(IntPtr hObject);
    
    
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool GetVolumeNameForVolumeMountPoint(string lpszVolumeMountPoint,
        StringBuilder lpszVolumeName, int cchBufferLength);
}