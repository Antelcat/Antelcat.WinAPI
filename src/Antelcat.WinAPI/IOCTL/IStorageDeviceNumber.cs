using Antelcat.WinAPI.Wdm;

namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// <see cref="IOCTL.Interop.IOCTL_STORAGE_GET_DEVICE_NUMBER"/>
/// </summary>
public interface IStorageDeviceNumber
{
    /// <summary>
    /// 设备类型 <see cref="DeviceType"/>
    /// </summary>
    public DeviceType DeviceType { get; }

    /// <summary>
    /// 此设备的编号
    /// </summary>
    public int DeviceNumber { get; }

    /// <summary>
    /// 设备的分区号（如果设备可以分区）。 否则，此成员为 –1。
    /// </summary>
    public int PartitionNumber { get; }
}