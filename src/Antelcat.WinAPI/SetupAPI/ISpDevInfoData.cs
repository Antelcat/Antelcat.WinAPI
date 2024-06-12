using System;

namespace Antelcat.WinAPI.SetupAPI;

/// <summary>
/// SP_DEVINFO_DATA
/// </summary>
public interface ISpDevInfoData
{
    public int CbSize { get; }
    public Guid ClassGuid { get; }
    public uint DevInst { get; }
}