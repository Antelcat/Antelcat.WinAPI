using System.Runtime.InteropServices;
using Antelcat.WinAPI.Wdm;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct STORAGE_DEVICE_NUMBER : IStorageDeviceNumber
{
    public uint deviceType;
    public uint deviceNumber;
    public int  partitionNumber;

    public DeviceType DeviceType      => (DeviceType)deviceType;
    public int       DeviceNumber    => (int)deviceNumber;
    public int        PartitionNumber => partitionNumber;
}