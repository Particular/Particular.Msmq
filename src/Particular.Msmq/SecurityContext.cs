//------------------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;
    using Particular.Msmq.Interop;

    sealed class SecurityContext : IDisposable
    {
        readonly SecurityContextHandle handle;
        bool disposed;

        internal SecurityContext(SecurityContextHandle securityContext)
        {
            handle = securityContext;
        }

        internal SecurityContextHandle Handle
        {
            get
            {
                ObjectDisposedException.ThrowIf(disposed, GetType().Name);

                return handle;
            }
        }

        public void Dispose()
        {
            handle.Close();
            disposed = true;
        }
    }
}
