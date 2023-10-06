//------------------------------------------------------------------------------
// <copyright file="MessageQueueTransactionType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    enum MessageQueueTransactionType
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        None = NativeMethods.QUEUE_TRANSACTION_NONE,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Automatic = NativeMethods.QUEUE_TRANSACTION_MTS,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Single = NativeMethods.QUEUE_TRANSACTION_SINGLE,
    }
}
