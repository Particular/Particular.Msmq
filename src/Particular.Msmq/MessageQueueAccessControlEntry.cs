namespace Particular.Msmq
{
    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    class MessageQueueAccessControlEntry : AccessControlEntry
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public MessageQueueAccessControlEntry(Trustee trustee, MessageQueueAccessRights rights)
            : base(trustee)
        {
            CustomAccessRights |= (int)rights;
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public MessageQueueAccessControlEntry(Trustee trustee, MessageQueueAccessRights rights, AccessControlEntryType entryType)
            : base(trustee)
        {
            CustomAccessRights |= (int)rights;
            EntryType = entryType;
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public MessageQueueAccessRights MessageQueueAccessRights
        {
            get
            {
                return (MessageQueueAccessRights)CustomAccessRights;
            }
            set
            {
                CustomAccessRights = (int)value;
            }
        }
    }
}
