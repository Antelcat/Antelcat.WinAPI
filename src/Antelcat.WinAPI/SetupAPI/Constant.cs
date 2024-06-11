// ReSharper disable InconsistentNaming

using System;

namespace Antelcat.WinAPI.SetupAPI;

internal static class Constant
{
    public const int DIGCF_PRESENT         = 0x00000002;
    public const int DIGCF_DEVICEINTERFACE = 0x00000010;
    public const int SPDRP_DEVICEDESC      = 0x00000000;

    public static Guid GUID_DEVINTERFACE_DISK = Guid.Parse("53F56307-B6BF-11D0-94F2-00A0C91EFB8B");
}