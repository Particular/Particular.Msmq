namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    enum AccessControlEntryType
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Allow = NativeMethods.GRANT_ACCESS,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Set = NativeMethods.SET_ACCESS,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Deny = NativeMethods.DENY_ACCESS,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Revoke = NativeMethods.REVOKE_ACCESS
    }
}
