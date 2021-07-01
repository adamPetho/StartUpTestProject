using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LinuxStuff();
            Thread.Sleep(2000);

            Console.WriteLine("Done.");
        }

        private static void LinuxStuff()
        {
            ProcessStartInfo processStartInfo = new("/bin/bash", "-c \"ls -l\"");
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = false;

            System.Diagnostics.Process proc = new();
            proc.StartInfo = processStartInfo;
            proc.Start();

            string result = proc.StandardOutput.ReadToEnd();
            Console.WriteLine(result);
            proc.Dispose();
        }
    }
}
