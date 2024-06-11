using System;
using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.SetupAPI.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct SP_DEVINFO_DATA
{
    public int    cbSize;
    public Guid   classGuid;
    public uint   devInst;
    public IntPtr reserved;
}