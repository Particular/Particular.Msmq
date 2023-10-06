//------------------------------------------------------------------------------
// <copyright file="HashAlgorithm.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>
    ///       Specifies the hash algorithm used by Message
    ///       Queuing when authenticating messages.
    ///
    ///    </para>
    /// </devdoc>
    enum HashAlgorithm
    {

        /// <devdoc>
        ///    <para>
        ///       No hashing
        ///       algorithm.
        ///
        ///    </para>
        /// </devdoc>
        None = 0,

        /// <devdoc>
        ///    <para>
        ///       MD2 hashing algorithm.
        ///    </para>
        /// </devdoc>
        Md2 = NativeMethods.CALG_MD2,

        /// <devdoc>
        ///    <para>
        ///       MD4 hashing algorithm.
        ///
        ///    </para>
        /// </devdoc>
        Md4 = NativeMethods.CALG_MD4,

        /// <devdoc>
        ///    <para>
        ///       MD5 hashing algorithm.
        ///    </para>
        /// </devdoc>
        Md5 = NativeMethods.CALG_MD5,

        /// <devdoc>
        ///    <para>
        ///       SHA hashing algorithm.
        ///    </para>
        /// </devdoc>
        Sha = NativeMethods.CALG_SHA,

        /// <devdoc>
        ///    <para>
        ///       MAC keyed hashing algorithm.
        ///    </para>
        /// </devdoc>
        Mac = NativeMethods.CALG_MAC,

        /// <devdoc>
        ///    <para>
        ///       SHA256 hashing algorithm.
        ///    </para>
        /// </devdoc>
        Sha256 = NativeMethods.CALG_SHA256,

        /// <devdoc>
        ///    <para>
        ///       SHA384 hashing algorithm.
        ///    </para>
        /// </devdoc>
        Sha384 = NativeMethods.CALG_SHA384,

        /// <devdoc>
        ///    <para>
        ///       SHA512 hashing algorithm.
        ///    </para>
        /// </devdoc>
        Sha512 = NativeMethods.CALG_SHA512,
    }
}
