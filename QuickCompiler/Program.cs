using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace QuickCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QuickCompiler started.\n");

            //here we are calling our threads.
            Dialog.FolderBrowser.CallFolderBrowserThread();
            Dialog.FileBrowser.CallFileBrowserThread();

            try
            {
                //here we are creating a process that stands for calling cmd commands.
                using (Process p = new Process())
                {
                    Console.WriteLine("\ncompile phase has been started..\nthis may take a while. please check your bin file.");

                    p.StartInfo = new ProcessStartInfo("cmd.exe")
                    {
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        UseShellExecute = false,
                        WorkingDirectory = @"d:\"
                    };

                    p.Start();

                    p.StandardInput.WriteLine($"cd {Settings.solutionPath}");
                    p.StandardInput.WriteLine($"\"{Settings.devenvPath}\" \"{Settings.solutionName}\" /rebuild");
                    p.WaitForExit();
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
