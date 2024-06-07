using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Antelcat.AutoGen.ComponentModel.Marshal;

namespace Antelcat.WinAPI.IOCTL.Structs;

/// <summary>
/// ushort[36]
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[AutoUnmanagedArray(typeof(ushort), 36)]
[DebuggerDisplay("{String}")]
public partial struct UnmanagedArray
{
    /// <summary>
    /// ASCII String
    /// </summary>
    public string String => Encoding.ASCII.GetString(
        Enumerate()
            .Select(static x => (byte)x)
            .ToArray());
}