namespace Particular.Msmq
{
    using System;
    using System.ComponentModel;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    class Trustee
    {
        string name;
        TrusteeType trusteeType;

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public string Name
        {
            get { return name; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                name = value;
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
            get { return trusteeType; }
            set
            {
                if (!ValidationUtility.ValidateTrusteeType(value))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(TrusteeType));
                }

                trusteeType = value;
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
