using Antelcat.WinAPI.IOCTL;

namespace Antelcat.WinAPI.UnitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        DeviceIOControl.Run();
    }
}