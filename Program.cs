using System;
using System.Reflection;

namespace Coree.Dotnet.VsVsix
{
    internal class Program
    {
        static void Main()
        {
            if (System.OperatingSystem.IsWindows())
            {
                var EnviromentWithoutCaller = Environment.CommandLine.TrimStart(Assembly.GetExecutingAssembly().Location.ToCharArray()).TrimStart();
                Console.WriteLine($@"This is just a wrapper command please see. https://github.com/microsoft/vsixbootstrapper");
                Console.WriteLine($@"VSIXBootstrapper.exe {EnviromentWithoutCaller}");
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = "VSIXBootstrapper.exe", Arguments = EnviromentWithoutCaller, WorkingDirectory=@$"{AppDomain.CurrentDomain.BaseDirectory}..\..\..\",UseShellExecute=true });
            }
            else
            {
                Console.WriteLine("This command is only supported on Windows.");
            }
        }
    }
}