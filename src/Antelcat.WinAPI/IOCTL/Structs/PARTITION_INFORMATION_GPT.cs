using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Antelcat.WinAPI.Extensions;

namespace Antelcat.WinAPI.IOCTL.Structs;

[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay("{PartitionTypeName}")]
internal struct PARTITION_INFORMATION_GPT : IPartitionInformationGpt
{
    public Guid           partitionType;
    public Guid           partitionId;
    public ulong          attributes;
    public UnmanagedArray name;

    public Guid  PartitionType => partitionType;
    public Guid  PartitionId   => partitionId;
    public ulong Attributes    => attributes;

    public string Name => name.String;

    private string? PartitionTypeName => this.PartitionTypeName();
}