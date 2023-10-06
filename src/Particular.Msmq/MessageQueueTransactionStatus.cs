//------------------------------------------------------------------------------
// <copyright file="MessageQueueTransactionStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    enum MessageQueueTransactionStatus
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Aborted = 0,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Committed = 1,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Initialized = 2,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Pending = 3,
    }

}
