namespace Particular.Msmq
{
    using System;
    using System.ComponentModel;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    class AccessControlEntry
    {
        //const int customRightsMask   = 0x0000ffff;
        const StandardAccessRights standardRightsMask = (StandardAccessRights)0x001f0000;
        const GenericAccessRights genericRightsMask = unchecked((GenericAccessRights)0xf0000000);

        internal int accessFlags = 0;

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public AccessControlEntry()
        {
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public AccessControlEntry(Trustee trustee)
        {
            Trustee = trustee;
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public AccessControlEntry(Trustee trustee, GenericAccessRights genericAccessRights, StandardAccessRights standardAccessRights, AccessControlEntryType entryType)
        {
            GenericAccessRights = genericAccessRights;
            StandardAccessRights = standardAccessRights;
            Trustee = trustee;
            EntryType = entryType;
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public AccessControlEntryType EntryType
        {
            get;
            set
            {
                if (!ValidationUtility.ValidateAccessControlEntryType(value))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(AccessControlEntryType));
                }

                field = value;
            }
        } = AccessControlEntryType.Allow;

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        protected int CustomAccessRights
        {
            get
            {
                return accessFlags;
            }
            set
            {
                accessFlags = value;
            }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public GenericAccessRights GenericAccessRights
        {
            get
            {
                return (GenericAccessRights)accessFlags & genericRightsMask;
            }
            set
            {
                // make sure these flags really are genericAccessRights
                if ((value & genericRightsMask) != value)
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(GenericAccessRights));
                }

                accessFlags = (accessFlags & (int)~genericRightsMask) | (int)value;
            }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public StandardAccessRights StandardAccessRights
        {
            get
            {
                return (StandardAccessRights)accessFlags & standardRightsMask;
            }
            set
            {
                // make sure these flags really are standardAccessRights
                if ((value & standardRightsMask) != value)
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(StandardAccessRights));
                }

                accessFlags = (accessFlags & (int)~standardRightsMask) | (int)value;
            }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public Trustee Trustee
        {
            get;
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                field = value;
            }
        } = null;
    }
}
