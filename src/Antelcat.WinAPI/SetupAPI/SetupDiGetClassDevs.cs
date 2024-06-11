using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Antelcat.WinAPI.SetupAPI.Structs;

namespace Antelcat.WinAPI.SetupAPI;

/// <summary>
/// 
/// </summary>
public static class SetupDiGetClassDevs
{
    internal static IEnumerable<string> SetupDiEnumDevicesInfo()
    {
        var deviceInfoSet = Native.Setupapi.SetupDiGetClassDevs(
            ref Constant.GUID_DEVINTERFACE_DISK,
            IntPtr.Zero,
            IntPtr.Zero,
            Constant.DIGCF_PRESENT | Constant.DIGCF_DEVICEINTERFACE);

        if (deviceInfoSet == IntPtr.Zero) yield break;

        try
        {
            uint index          = 0;
            var  deviceInfoData = new SP_DEVINFO_DATA();
            deviceInfoData.cbSize = Marshal.SizeOf(deviceInfoData);

            while (Native.Setupapi.SetupDiEnumDeviceInfo(deviceInfoSet, index, ref deviceInfoData))
            {
                var propertyBuffer = new byte[1024];
                if (Native.Setupapi.SetupDiGetDeviceRegistryProperty(deviceInfoSet,
                        ref deviceInfoData,
                        Constant.SPDRP_DEVICEDESC,
                        out _,
                        propertyBuffer,
                        (uint)propertyBuffer.Length,
                        out var requiredSize))
                    yield return Encoding.Unicode.GetString(propertyBuffer, 0, (int)requiredSize);

                index++;
            }

        }
        finally
        {
            Native.Setupapi.SetupDiDestroyDeviceInfoList(deviceInfoSet);
        }
    }
}