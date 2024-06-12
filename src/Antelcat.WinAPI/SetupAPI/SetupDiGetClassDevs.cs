using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Antelcat.WinAPI.SetupAPI.Structs;

namespace Antelcat.WinAPI.SetupAPI;

/// <summary>
/// 
/// </summary>
static partial class Interop
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="indexes"></param>
    /// <returns></returns>
    public static IEnumerable<ISpDevInfoData> SetupDiEnumDeviceInfo(params int[] indexes)
    {
        var deviceInfoSet = Native.Setupapi.SetupDiGetClassDevs(
            ref GUID_DEVINTERFACE_DISK,
            IntPtr.Zero,
            IntPtr.Zero,
            DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
        if (deviceInfoSet == IntPtr.Zero) yield break;
        try
        {
            foreach (var index in indexes)
            {
                var deviceInfoData = new SP_DEVINFO_DATA();
                deviceInfoData.cbSize = Marshal.SizeOf(deviceInfoData);
                if (Native.Setupapi.SetupDiEnumDeviceInfo(deviceInfoSet, (uint)index, ref deviceInfoData))
                {
                    yield return deviceInfoData;
                    /*var propertyBuffer = new byte[1024];
                    Native.Setupapi.SetupDiGetDeviceRegistryProperty(deviceInfoSet,
                        ref deviceInfoData,
                        SPDRP_DEVICEDESC,
                        out _,
                        propertyBuffer,
                        (uint)propertyBuffer.Length,
                        out var requiredSize);*/
                }
            }
        }
        finally
        {
            Native.Setupapi.SetupDiDestroyDeviceInfoList(deviceInfoSet);
        }
    }

    /// <summary>
    /// 获取所有硬盘信息
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<string> EnumDiskInfo()
    {
        var deviceInfoSet = Native.Setupapi.SetupDiGetClassDevs(
            ref GUID_DEVINTERFACE_DISK,
            IntPtr.Zero,
            IntPtr.Zero,
            DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);

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
                        SPDRP_DEVICEDESC,
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