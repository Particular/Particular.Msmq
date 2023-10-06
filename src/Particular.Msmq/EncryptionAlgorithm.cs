//------------------------------------------------------------------------------
// <copyright file="EncryptionAlgorithm.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>
    ///       Specifies the encryption algorithm used to encrypt the message body of a
    ///       private message.
    ///
    ///    </para>
    /// </devdoc>
    enum EncryptionAlgorithm
    {

        /// <devdoc>
        ///    <para>
        ///       No encryption.
        ///    </para>
        /// </devdoc>
        None = 0,

        /// <devdoc>
        ///    <para>
        ///       The value MQMSG_CALG_RC2. This is the default value for
        ///       the <see langword='EncryptAlgorithm'/> property of the Message Queuing
        ///       application's <see langword='MSMQMessage '/>
        ///
        ///
        ///       object.
        ///
        ///    </para>
        /// </devdoc>
        Rc2 = NativeMethods.CALG_RC2,

        /// <devdoc>
        ///    <para>
        ///       The value MQMSG_CALG_RC4. This corresponds to the less
        ///       secure option for the <see langword='EncryptAlgorithm '/>property of the
        ///       Message Queuing application's <see langword='MSMQMessage '/>
        ///
        ///       object.
        ///
        ///    </para>
        /// </devdoc>
        Rc4 = NativeMethods.CALG_RC4,
    }
}
