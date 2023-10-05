//------------------------------------------------------------------------------
// <copyright file="ReceiveCompletedEventArgs.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Messaging.Msmq
{
    using System;

    /// <include file='doc\ReceiveCompletedEventArgs.uex' path='docs/doc[@for="ReceiveCompletedEventArgs"]/*' />
    /// <devdoc>
    /// <para>Provides data for the <see cref='System.Messaging.MessageQueue.ReceiveCompleted'/>
    /// event.</para>
    /// </devdoc>
    public class ReceiveCompletedEventArgs : EventArgs
    {
        private IAsyncResult result;
        private Message message;
        private readonly MessageQueue sender;

        /// <include file='doc\ReceiveCompletedEventArgs.uex' path='docs/doc[@for="ReceiveCompletedEventArgs.ReceiveCompletedEventArgs"]/*' />
        /// <internalonly/>
        internal ReceiveCompletedEventArgs(MessageQueue sender, IAsyncResult result)
        {
            this.result = result;
            this.sender = sender;
        }

        /// <include file='doc\ReceiveCompletedEventArgs.uex' path='docs/doc[@for="ReceiveCompletedEventArgs.AsyncResult"]/*' />
        /// <devdoc>
        ///    <para>Contains the result of the asynchronous
        ///       operation requested.</para>
        /// </devdoc>
        public IAsyncResult AsyncResult
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }

        /// <include file='doc\ReceiveCompletedEventArgs.uex' path='docs/doc[@for="ReceiveCompletedEventArgs.Message"]/*' />
        /// <devdoc>
        ///    <para>The end result of the posted asynchronous receive
        ///       operation.</para>
        /// </devdoc>
        public Message Message
        {
            get
            {
                if (message == null)
                {
                    try
                    {
                        message = sender.EndReceive(result);
                    }
                    catch
                    {
                        throw;
                    }
                }

                return message;
            }
        }
    }
}
