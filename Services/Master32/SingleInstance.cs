using System;
using System.Threading;

namespace Master32
{
    internal class SingleInstance
    {
        private bool firstInstance = false;
        private const string MutexName = "master32Update";

        public SingleInstance()
        {
            Mutex mutex = null;
            try
            {
                mutex = Mutex.OpenExisting("master32Update");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                this.firstInstance = true;
            }
            if (mutex == null)
            {
                mutex = new Mutex(false, "master32Update");
                GC.KeepAlive(mutex);
            }
        }

        public bool FirstInstance
        {
            get
            {
                return this.firstInstance;
            }
        }
    }
}

