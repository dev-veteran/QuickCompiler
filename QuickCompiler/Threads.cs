using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickCompiler
{
    public class Threads
    {
        public static Thread folderBrowser, fileBrowser;

        //here we are calling our STA threads for avoid from ThreadStateException.
        public static void CallSTAThread(Thread targetThread, ThreadStart targetEvent, ThreadPriority priority = ThreadPriority.Normal)
        {
            targetThread = new Thread(new ThreadStart(targetEvent)) { Priority = priority };
            targetThread.SetApartmentState(ApartmentState.STA);
            targetThread.Start();

            //helps to wait thread-complete.
            targetThread.Join(); 
        }
    }
}
