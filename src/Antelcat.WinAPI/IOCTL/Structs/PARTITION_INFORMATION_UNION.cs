using System.Runtime.InteropServices;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Explicit)]
internal struct PARTITION_INFORMATION_UNION : IPartitionInformationMbrOrGpt
{
    [FieldOffset(0)] public PARTITION_INFORMATION_MBR mbr;
    [FieldOffset(0)] public PARTITION_INFORMATION_GPT gpt;
    public                  IPartitionInformationMbr  Mbr => mbr;
    public                  IPartitionInformationGpt  Gpt => gpt;
}