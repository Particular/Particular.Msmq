namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    [Flags]
    enum GenericAccessRights
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        All = 1 << 28,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Execute = 1 << 29,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Write = 1 << 30,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Read = 1 << 31,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        None = 0
    }
}
