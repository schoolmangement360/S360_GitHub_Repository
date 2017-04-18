using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Logging
{
    public static class S360Log
    {
        /*
        * This creates your Log. 
        * Notice that in the config file we defined that everything should go into the file.
        * (and if you set the console, it'll output to it as well).
        */
        public static Logger Instance { get; private set; }

        static S360Log()
        {
            Instance = LogManager.GetCurrentClassLogger();
        }
    }
}
