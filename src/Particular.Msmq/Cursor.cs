//------------------------------------------------------------------------------
// <copyright file="MessageEnumerator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;
    using Particular.Msmq.Interop;

    sealed class Cursor : IDisposable
    {

        CursorHandle handle;
        bool disposed;


        internal Cursor(MessageQueue queue)
        {
            int status = SafeNativeMethods.MQCreateCursor(queue.MQInfo.ReadHandle, out CursorHandle result);
            if (MessageQueue.IsFatalError(status))
            {
                throw new MessageQueueException(status);
            }

            handle = result;
        }


        internal CursorHandle Handle
        {
            get
            {
                ObjectDisposedException.ThrowIf(disposed, GetType().Name);

                return handle;
            }
        }


        public void Close()
        {
            handle?.Close();
            handle = null;
        }


        public void Dispose()
        {
            Close();
            disposed = true;
        }

    }
}
