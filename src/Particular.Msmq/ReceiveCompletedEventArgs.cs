//------------------------------------------------------------------------------
// <copyright file="ReceiveCompletedEventArgs.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    /// <para>Provides data for the <see cref='MessageQueue.ReceiveCompleted'/>
    /// event.</para>
    /// </devdoc>
    class ReceiveCompletedEventArgs : EventArgs
    {
        readonly MessageQueue sender;

        /// <internalonly/>
        internal ReceiveCompletedEventArgs(MessageQueue sender, IAsyncResult result)
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
        ///    <para>The end result of the posted asynchronous receive
        ///       operation.</para>
        /// </devdoc>
        public Message Message
        {
            get
            {
                if (field == null)
                {
                    try
                    {
                        field = sender.EndReceive(AsyncResult);
                    }
                    catch
                    {
                        throw;
                    }
                }

                return field;
            }
        }
    }
}
