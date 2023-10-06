//------------------------------------------------------------------------------
// <copyright file="EncryptionRequired.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>
    ///       Specifies the privacy level of messages received by the queue.
    ///
    ///    </para>
    /// </devdoc>
    enum EncryptionRequired
    {
        /// <devdoc>
        ///    <para>
        ///       Accepts
        ///       only
        ///       non-private (non-encrypted) messages.
        ///
        ///    </para>
        /// </devdoc>
        None = NativeMethods.QUEUE_PRIVACY_LEVEL_NONE,

        /// <devdoc>
        ///    <para>
        ///       Does not force privacy. Accepts private (encrypted) messages and non-private (non-encrypted) messages.
        ///
        ///    </para>
        /// </devdoc>
        Optional = NativeMethods.QUEUE_PRIVACY_LEVEL_OPTIONAL,

        /// <devdoc>
        ///    <para>
        ///       Accepts only private (encrypted) messages.
        ///    </para>
        /// </devdoc>
        Body = NativeMethods.QUEUE_PRIVACY_LEVEL_BODY
    }
}
