namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    [Flags]
    enum StandardAccessRights
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Delete = 1 << 16,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        ReadSecurity = 1 << 17,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        WriteSecurity = 1 << 18,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Synchronize = 1 << 20,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        ModifyOwner = 1 << 19,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Read = ReadSecurity,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Write = ReadSecurity,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Execute = ReadSecurity,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Required = Delete | WriteSecurity | ModifyOwner,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        All = Delete | WriteSecurity | ModifyOwner | ReadSecurity | Synchronize,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        None = 0
    }
}
