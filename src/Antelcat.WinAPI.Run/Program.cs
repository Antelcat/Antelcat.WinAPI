// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System.Management;
using System.Reflection;
using Antelcat.WinAPI.IOCTL;


System.Security.Principal.WindowsIdentity  identity  = System.Security.Principal.WindowsIdentity.GetCurrent();
System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
//判断当前登录用户是否为管理员
if (!principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
{
    //创建启动对象
    var startInfo = new System.Diagnostics.ProcessStartInfo
    {
        UseShellExecute  = true,
        WorkingDirectory = Environment.CurrentDirectory,
        FileName         = Assembly.GetExecutingAssembly().Location,
        //设置启动动作,确保以管理员身份运行
        Verb = "runas"
    };
    try
    {
        System.Diagnostics.Process.Start(startInfo);
    }
    catch
    {
        return;
    }

    //退出
    Environment.Exit(6);
}

var root = Path.GetPathRoot(AppContext.BaseDirectory);
ThrowIfNull(root, new NullReferenceException(nameof(root)));
Console.WriteLine($"Root : {root}");

var disk = Antelcat.WinAPI.FileAPI.Interop.GetVolumeName(root);
ThrowIfNull(disk, new NullReferenceException(nameof(disk)));
var guid = Guid.Parse(disk.AsSpan(@"\\?\Volume{".Length, 36));
Console.WriteLine($"GUID : {guid}");
var number = Interop.GetDeviceNumber($@"\\.\{root[..^1]}");
Console.WriteLine($"Number : {number.DeviceNumber}");
var numbers = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
    .Get()
    .Cast<ManagementObject>()
    .OrderBy(x => int.Parse(x["Tag"].ToString().Substring(@"\\.\PHYSICALDRIVE".Length)))
    .Select(static x => x["SerialNumber"])
    .ToArray();
Console.WriteLine(string.Join("\n", numbers.Select(x => x.ToString())));
var serialNumber = numbers.ElementAt(number.DeviceNumber);

ThrowIfNull(serialNumber, new NullReferenceException(nameof(serialNumber)));
Console.WriteLine($"SerialNumber : {serialNumber}");
Console.Read();
return;


void ThrowIfNull([NotNull] object? obj, Exception e)
{
    if (obj is not null) return;
    Console.WriteLine(e);
    Console.Read();
    Environment.Exit(0);
}