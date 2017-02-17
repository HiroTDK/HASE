using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HASE
{
    namespace HASE
    {
        public class BaseClass : IDisposable                                        // Creates an inheritable class that can be cleaned up.
        {
            bool disposed = false;                                                  // Flag: Has Dispose already been called?
            SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);              // Instantiate a SafeHandle instance.

            public void Dispose()                                                   // Public implementation of Dispose pattern.
            {
                Dispose(true);                                                      // Calls the protected implementation.
                GC.SuppressFinalize(this);                                          // Suppress finalizing to prevent redundant cleanup.
            }

            protected virtual void Dispose(bool disposing)                          // Protected implementation of Dispose pattern.
            {
                if (disposed) { return; }                                           // If already called, ignore future calls.

                if (disposing)                                                      // If we are disposing, do cleanup.
                {
                    handle.Dispose();                                               // Cleanup stuff here.
                    // Possible future cleanup.
                }
                
                disposed = true;                                                    // Set disposed boolean to prevent redundant calls.
            }

        }
    }
}
