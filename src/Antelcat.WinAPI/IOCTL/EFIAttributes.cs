using System;

namespace Antelcat.WinAPI.IOCTL;

/// <summary>
/// 可扩展固件接口 (EFI) 分区的属性。
/// </summary>
[Flags]
public enum EFIAttributes : ulong
{
    /// <summary>
    /// 如果设置了此属性，则计算机需要分区才能正常运行。
    /// 例如，必须为 OEM 分区设置此属性。 请注意，如果设置了此属性，则可以使用 DiskPart.exe
    /// 实用工具执行分区操作，例如删除分区。 但是，由于分区不是卷，因此无法使用 DiskPart.exe
    /// 实用工具对分区执行卷操作。
    /// 可以为基本磁盘和动态磁盘设置此属性。 如果它是为基本磁盘上的分区设置的，并且磁盘转换为动态磁盘，
    /// 则分区仍然是基本分区，即使磁盘的其余部分是动态磁盘。 这是因为分区被视为 GPT 磁盘上的 OEM 分区。
    /// </summary>
    GPT_ATTRIBUTE_PLATFORM_REQUIRED = 0x0000000000000001,

    /// <summary>
    /// 如果设置了此属性，则当磁盘移动到另一台计算机或计算机首次看到磁盘时，分区默认情况下不会收到驱动器号。
    /// 此属性在存储区域网络 (SAN) 环境中很有用。
    /// 尽管其名称为 ，但可以为基本磁盘和动态磁盘设置此属性。
    /// </summary>
    GPT_BASIC_DATA_ATTRIBUTE_NO_DRIVE_LETTER = 0x8000000000000000,

    /// <summary>
    /// 如果设置了此属性，装载管理器不会检测到分区。
    /// 因此，分区不接收驱动器号，不接收卷 GUID 路径，不托管装载的文件夹 (也称为卷装入点) ，并且不通过调用
    /// FindFirstVolume 和 FindNextVolume 枚举。 这可确保磁盘碎片整理程序等应用程序不会访问分区。
    /// 卷影复制服务 (VSS) 使用此属性。
    /// 尽管其名称为 ，但可以为基本磁盘和动态磁盘设置此属性。
    /// </summary>
    GPT_BASIC_DATA_ATTRIBUTE_HIDDEN = 0x4000000000000000,

    /// <summary>
    /// 如果设置了此属性，则分区是另一个分区的卷影副本。
    /// VSS 使用此属性。 此属性指示文件系统筛选器基于驱动程序的软件 (，例如防病毒程序) 以避免附加到卷。
    /// 应用程序可以使用 属性将卷影复制卷与生产卷区分开来。 例如，执行快速恢复的应用程序会中断卷影复制 LUN，
    /// 并清除只读和隐藏属性以及此属性。 此属性在创建卷影副本时设置，并在卷影副本损坏时清除。
    /// 尽管其名称为 ，但可以为基本磁盘和动态磁盘设置此属性。
    /// Windows Server 2003： 在具有 SP1 的 Windows Server 2003 之前，不支持此属性。
    /// </summary>
    GPT_BASIC_DATA_ATTRIBUTE_SHADOW_COPY = 0x2000000000000000,

    /// <summary>
    /// 如果设置了此属性，则分区为只读。
    /// 写入分区将失败。 IOCTL_DISK_IS_WRITABLE 将失败并 显示ERROR_WRITE_PROTECT Win32 错误代码，
    /// 这会导致文件系统装载为只读（如果存在文件系统）。
    /// VSS 使用此属性。
    /// 不要为动态磁盘设置此属性。 设置它可能会导致 I/O 错误，并阻止文件系统正确装载。
    /// </summary>
    GPT_BASIC_DATA_ATTRIBUTE_READ_ONLY = 0x1000000000000000,
}