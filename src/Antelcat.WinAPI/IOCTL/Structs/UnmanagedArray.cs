using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Antelcat.AutoGen.ComponentModel.Marshal;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
[AutoUnmanagedArray(typeof(ushort), 36)]
[DebuggerDisplay("{String}")]
public partial struct UnmanagedArray
{
    public string String => Encoding.ASCII.GetString(
        Enumerable
            .Select<ushort, byte>(Enumerate(), static x => (byte)x)
            .ToArray());
}