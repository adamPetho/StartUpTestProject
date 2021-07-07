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
            MacOsStuff();
            Thread.Sleep(2000);

            Console.WriteLine("Done.");
        }

        private static void LinuxStuff()
        {
            string argumentsForLinux = "ls -l";
            ProcessStartInfo processStartInfo = new() 
            {
                UseShellExecute = true,
                CreateNoWindow = false,
                Arguments = argumentsForLinux
            };

            Process.Start(processStartInfo);
        }

        private static void MacOsStuff()
        {
            string argumentToAdd = $"-c \"osascript -e \' tell application \\\"System Events\\\" to make new login item at end of login items with properties {{name:\\\"WasabiWallet\\\", path:\\\"/Applications/WasabiWallet.app\\\",hidden:false}} \' \"";
            string argumentsToDelete = $"-c \"osascript -e \' tell application \\\"System Events\\\" to delete login item \\\"WasabiWallet\\\" \' \"";
            ProcessStartInfo processInfo = new()
            {
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = "/bin/bash",
                Arguments = argumentToAdd,
                CreateNoWindow = false
            };

            Process.Start(processInfo);

            //Process.Start("osascript -e 'tell application \"System Events\" to delete login item \"WasabiWallet\"'");
        }
    }
}
