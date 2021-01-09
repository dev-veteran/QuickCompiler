using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace QuickCompiler
{
    public class Dialog
    {
        public class FolderBrowser
        {
            static void FolderBrowserThread()
            {
                FolderBrowserDialog fDialog = new FolderBrowserDialog();

                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.solutionPath = fDialog.SelectedPath;
                    Console.WriteLine($"Project Path: {fDialog.SelectedPath}");
                }
                else
                {
                    Console.WriteLine("FolderBrowserDialog passed.. Exiting");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }

            public static void CallFolderBrowserThread()
            {
                Threads.CallSTAThread(Threads.folderBrowser, FolderBrowserThread);
            }
        }

        public class FileBrowser
        {
            static void FileBrowserThread()
            {
                OpenFileDialog fDialog = new OpenFileDialog()
                {
                    Filter = "Solution File (.sln) | *.sln;*.SLN"
                };

                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.solutionName = fDialog.SafeFileName;
                    Console.WriteLine($"Solution Name: {fDialog.SafeFileName}");
                }
                else
                {
                    Console.WriteLine("OpenFileDialog passed.. Exiting");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }

            public static void CallFileBrowserThread()
            {
                Threads.CallSTAThread(Threads.fileBrowser, FileBrowserThread);
            }
        }
    }
}
