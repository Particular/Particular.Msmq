namespace Particular.Msmq
{
    using System;
    using System.ComponentModel;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    class Trustee
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public string Name
        {
            get;
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                field = value;
            }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public string SystemName { get; set; }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public TrusteeType TrusteeType
        {
            get;
            set
            {
                if (!ValidationUtility.ValidateTrusteeType(value))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(TrusteeType));
                }

                field = value;
            }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public Trustee()
        {
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public Trustee(string name) : this(name, null) { }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public Trustee(string name, string systemName) : this(name, systemName, TrusteeType.Unknown) { }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public Trustee(string name, string systemName, TrusteeType trusteeType)
        {
            Name = name;
            SystemName = systemName;
            TrusteeType = trusteeType;
        }
    }
}
