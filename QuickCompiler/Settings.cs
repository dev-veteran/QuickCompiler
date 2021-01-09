using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickCompiler
{
    public static class Settings
    {
        //devenv path is our visual studio 2019 IDE path.
        public static string devenvPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe";
       
        //solution path is our target solution path.
        public static string solutionPath = string.Empty;
        public static string solutionName = string.Empty;
    }
}
