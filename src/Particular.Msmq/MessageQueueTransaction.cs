//------------------------------------------------------------------------------
// <copyright file="MessageQueueTransaction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;
    using System.Threading;
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    class MessageQueueTransaction : IDisposable
    {
        ITransaction internalTransaction;
        bool disposed;

        /// <devdoc>
        ///    <para>
        ///       Creates a new Message Queuing internal transaction context.
        ///    </para>
        /// </devdoc>
        public MessageQueueTransaction()
        {
            Status = MessageQueueTransactionStatus.Initialized;
        }

        internal ITransaction InnerTransaction => internalTransaction;

        /// <devdoc>
        ///    <para>
        ///       The status of the transaction that this object represents.
        ///    </para>
        /// </devdoc>
        public MessageQueueTransactionStatus Status { get; private set; }

        /// <devdoc>
        ///    <para>
        ///       Rolls back the pending internal transaction.
        ///    </para>
        /// </devdoc>
        public void Abort()
        {
            lock (this)
            {
                if (internalTransaction == null)
                {
                    throw new InvalidOperationException(Res.GetString(Res.TransactionNotStarted));
                }
                else
                {
                    AbortInternalTransaction();
                }
            }
        }

        /// <internalonly/>
        void AbortInternalTransaction()
        {
            int status = internalTransaction.Abort(0, 0, 0);
            if (MessageQueue.IsFatalError(status))
            {
                throw new MessageQueueException(status);
            }

            internalTransaction = null;
            Status = MessageQueueTransactionStatus.Aborted;
        }

        /// <devdoc>
        ///    <para>
        ///       Begins a new Message Queuing internal transaction context.
        ///    </para>
        /// </devdoc>
        public void Begin()
        {
            //Won't allow begining a new transaction after the object has been disposed.
            ObjectDisposedException.ThrowIf(disposed, GetType().Name);

            lock (this)
            {
                if (internalTransaction != null)
                {
                    throw new InvalidOperationException(Res.GetString(Res.TransactionStarted));
                }
                else
                {
                    int status = SafeNativeMethods.MQBeginTransaction(out internalTransaction);
                    if (MessageQueue.IsFatalError(status))
                    {
                        internalTransaction = null;
                        throw new MessageQueueException(status);
                    }

                    Status = MessageQueueTransactionStatus.Pending;
                }
            }
        }

        /// <internalonly/>
        internal ITransaction BeginQueueOperation()
        {
            //@TODO: This overload of Monitor.Enter is obsolete.  Please change this to use Monitor.Enter(ref bool), and remove the pragmas   -- ericeil
            Monitor.Enter(this);
            return internalTransaction;
        }

        /// <devdoc>
        ///    <para>
        ///       Commits a pending internal transaction.
        ///    </para>
        /// </devdoc>
        public void Commit()
        {
            lock (this)
            {
                if (internalTransaction == null)
                {
                    throw new InvalidOperationException(Res.GetString(Res.TransactionNotStarted));
                }
                else
                {
                    int status = internalTransaction.Commit(0, 0, 0);
                    if (MessageQueue.IsFatalError(status))
                    {
                        throw new MessageQueueException(status);
                    }

                    internalTransaction = null;
                    Status = MessageQueueTransactionStatus.Committed;
                }
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Disposes this transaction instance, if it is in a
        ///       pending status, the transaction will be aborted.
        ///    </para>
        /// </devdoc>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <devdoc>
        ///    <para>
        ///    </para>
        /// </devdoc>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if (internalTransaction != null)
                    {
                        AbortInternalTransaction();
                    }
                }
            }

            disposed = true;
        }

        /// <internalonly/>
        ~MessageQueueTransaction()
        {
            Dispose(false);
        }

        /// <internalonly/>
        internal void EndQueueOperation()
        {
            Monitor.Exit(this);
        }
    }
}
