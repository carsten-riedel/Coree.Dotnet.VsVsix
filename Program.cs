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
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo() { FileName = "VSIXBootstrapper.exe", Arguments = EnviromentWithoutCaller, WorkingDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}..\..\..\", UseShellExecute = true };
                var proc = new System.Diagnostics.Process(){ StartInfo = startInfo };
                proc.Start();
                proc.WaitForExit();
            }
            else
            {
                Console.WriteLine("This command is only supported on Windows.");
            }
        }
    }
}