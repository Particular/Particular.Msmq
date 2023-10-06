//------------------------------------------------------------------------------
// <copyright file="CryptographicProviderType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    Typically used when working with foreign queues. The type and name of the cryptographic
    ///    provider is required to validate the digital signature of a message sent to a foreign queue
    ///    or messages passed to MSMQ from a foreign queue.
    /// </devdoc>
    enum CryptographicProviderType
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        None = 0,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        RsaFull = NativeMethods.PROV_RSA_FULL,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        RsqSig = NativeMethods.PROV_RSA_SIG,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Dss = NativeMethods.PROV_DSS,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Fortezza = NativeMethods.PROV_FORTEZZA,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        MicrosoftExchange = NativeMethods.PROV_MS_EXCHANGE,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Ssl = NativeMethods.PROV_SSL,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        SttMer = NativeMethods.PROV_STT_MER,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        SttAcq = NativeMethods.PROV_STT_ACQ,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        SttBrnd = NativeMethods.PROV_STT_BRND,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        SttRoot = NativeMethods.PROV_STT_ROOT,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        SttIss = NativeMethods.PROV_STT_ISS,
    }
}
