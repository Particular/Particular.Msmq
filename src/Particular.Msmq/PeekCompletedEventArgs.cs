//------------------------------------------------------------------------------
// <copyright file="PeekCompletedEventArgs.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    /// <para>Provides data for the <see cref='MessageQueue.PeekCompleted'/> event. When your asynchronous
    ///    operation calls an event handler, an instance of this class is passed to the
    ///    handler.</para>
    /// </devdoc>
    class PeekCompletedEventArgs : EventArgs
    {
        Message message;
        readonly MessageQueue sender;

        /// <internalonly/>
        internal PeekCompletedEventArgs(MessageQueue sender, IAsyncResult result)
        {
            AsyncResult = result;
            this.sender = sender;
        }

        /// <devdoc>
        ///    <para>Contains the result of the asynchronous
        ///       operation requested.</para>
        /// </devdoc>
        public IAsyncResult AsyncResult { get; set; }

        /// <devdoc>
        ///    <para>The end result of the posted asynchronous peek
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
                        message = sender.EndPeek(AsyncResult);
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
