using System;
using System.Runtime.InteropServices;
using Antelcat.WinAPI.SetupAPI.Structs;

namespace Antelcat.WinAPI.Native;

internal static class Setupapi
{
    internal const string setupapi = "setupapi.dll";
    
    [DllImport(setupapi, CharSet = CharSet.Auto)]
    public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, uint Flags);

    [DllImport(setupapi, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);

    [DllImport(setupapi, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool SetupDiGetDeviceRegistryProperty(IntPtr DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, uint Property, out uint PropertyRegDataType, byte[] PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize);

    [DllImport(setupapi, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);
}