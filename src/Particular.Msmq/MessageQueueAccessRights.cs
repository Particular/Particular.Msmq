namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    [Flags]
    enum MessageQueueAccessRights
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        DeleteMessage = 0x00000001,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        PeekMessage = 0x00000002,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        WriteMessage = 0x00000004,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        DeleteJournalMessage = 0x00000008,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        SetQueueProperties = 0x00000010,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        GetQueueProperties = 0x00000020,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        DeleteQueue = 0x00010000,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        GetQueuePermissions = 0x00020000,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        ChangeQueuePermissions = 0x00040000,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        TakeQueueOwnership = 0x00080000,

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        ReceiveMessage = DeleteMessage | PeekMessage,

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        ReceiveJournalMessage = DeleteJournalMessage | PeekMessage,

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        GenericRead = GetQueueProperties | GetQueuePermissions | ReceiveMessage | ReceiveJournalMessage,

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        GenericWrite = GetQueueProperties | GetQueuePermissions | WriteMessage,

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        FullControl = DeleteMessage | PeekMessage | WriteMessage | DeleteJournalMessage |
                                 SetQueueProperties | GetQueueProperties | DeleteQueue | GetQueuePermissions |
                                 ChangeQueuePermissions | TakeQueueOwnership,
    }
}
