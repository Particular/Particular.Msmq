//------------------------------------------------------------------------------
// <copyright file="MessageQueueTransactionType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <include file='doc\MessageQueueTransactionType.uex' path='docs/doc[@for="MessageQueueTransactionType"]/*' />
    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    enum MessageQueueTransactionType
    {
        /// <include file='doc\MessageQueueTransactionType.uex' path='docs/doc[@for="MessageQueueTransactionType.None"]/*' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        None = NativeMethods.QUEUE_TRANSACTION_NONE,
        /// <include file='doc\MessageQueueTransactionType.uex' path='docs/doc[@for="MessageQueueTransactionType.Automatic"]/*' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Automatic = NativeMethods.QUEUE_TRANSACTION_MTS,
        /// <include file='doc\MessageQueueTransactionType.uex' path='docs/doc[@for="MessageQueueTransactionType.Single"]/*' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Single = NativeMethods.QUEUE_TRANSACTION_SINGLE,
    }
}
