using System;
using System.Threading;
using System.Windows.Forms;

namespace Common
{
    public static class Process
    {
        public static void ExcludeMultipleStartUp(string strProductName)
        {
            Mutex objMutex = new Mutex(false, strProductName);

            if (!objMutex.WaitOne(0, false))
            {
                return;
            }

            GC.KeepAlive(objMutex);
            Application.Run();
        }
    }
}
