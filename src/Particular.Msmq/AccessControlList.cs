namespace Particular.Msmq
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    class AccessControlList : CollectionBase
    {

        internal static readonly int UnknownEnvironment = 0;
        internal static readonly int W2kEnvironment = 1;
        internal static readonly int NtEnvironment = 2;
        internal static readonly int NonNtEnvironment = 3;

        // Double-checked locking pattern requires volatile for read/write synchronization
        static volatile int environment = UnknownEnvironment;

        static readonly object staticLock = new();

        public AccessControlList()
        {
        }

        internal static int CurrentEnvironment
        {
            get
            {
                if (environment == UnknownEnvironment)
                {
                    lock (staticLock)
                    {
                        if (environment == UnknownEnvironment)
                        {
                            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                            {
                                if (Environment.OSVersion.Version.Major >= 5)
                                {
                                    environment = W2kEnvironment;
                                }
                                else
                                {
                                    environment = NtEnvironment;
                                }
                            }
                            else
                            {
                                environment = NonNtEnvironment;
                            }
                        }
                    }
                }

                return environment;
            }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public int Add(AccessControlEntry entry)
        {
            return List.Add(entry);
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public void Insert(int index, AccessControlEntry entry)
        {
            List.Insert(index, entry);
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public int IndexOf(AccessControlEntry entry)
        {
            return List.IndexOf(entry);
        }

        internal static void CheckEnvironment()
        {
            if (CurrentEnvironment == NonNtEnvironment)
            {
                throw new PlatformNotSupportedException(Res.GetString(Res.WinNTRequired));
            }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public bool Contains(AccessControlEntry entry)
        {
            return List.Contains(entry);
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public void Remove(AccessControlEntry entry)
        {
            List.Remove(entry);
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public void CopyTo(AccessControlEntry[] array, int index)
        {
            List.CopyTo(array, index);
        }

        internal IntPtr MakeAcl(IntPtr oldAcl)
        {
            CheckEnvironment();

            int ACECount = List.Count;
            IntPtr newAcl;

            var entries = new NativeMethods.ExplicitAccess[ACECount];

            var mem = GCHandle.Alloc(entries, GCHandleType.Pinned);
            try
            {
                for (int i = 0; i < ACECount; i++)
                {
                    int sidSize = 0;
                    int domainSize = 0;

                    var ace = (AccessControlEntry)List[i];

                    if (ace.Trustee == null)
                    {
                        throw new InvalidOperationException(Res.GetString(Res.InvalidTrustee));
                    }

                    string name = ace.Trustee.Name;
                    if (name == null)
                    {
                        throw new InvalidOperationException(Res.GetString(Res.InvalidTrusteeName));
                    }

                    if ((ace.Trustee.TrusteeType == TrusteeType.Computer) && !name.EndsWith('$'))
                    {
                        name += "$";
                    }

                    if (!UnsafeNativeMethods.LookupAccountName(ace.Trustee.SystemName, name, 0, ref sidSize, null, ref domainSize, out int sidtype))
                    {
                        int errval = Marshal.GetLastWin32Error();
                        if (errval != 122)
                        {
                            throw new InvalidOperationException(Res.GetString(Res.CouldntResolve, ace.Trustee.Name, errval));
                        }
                    }

                    entries[i].data = Marshal.AllocHGlobal(sidSize);

                    StringBuilder domainName = new(domainSize);
                    if (!UnsafeNativeMethods.LookupAccountName(ace.Trustee.SystemName, name, entries[i].data, ref sidSize, domainName, ref domainSize, out sidtype))
                    {
                        throw new InvalidOperationException(Res.GetString(Res.CouldntResolveName, ace.Trustee.Name));
                    }

                    entries[i].grfAccessPermissions = ace.accessFlags;
                    entries[i].grfAccessMode = (int)ace.EntryType;
                    entries[i].grfInheritance = 0;
                    entries[i].pMultipleTrustees = 0;
                    entries[i].MultipleTrusteeOperation = NativeMethods.NO_MULTIPLE_TRUSTEE;
                    entries[i].TrusteeForm = NativeMethods.TRUSTEE_IS_SID;
                    entries[i].TrusteeType = (int)ace.Trustee.TrusteeType;
                }

                int err = SafeNativeMethods.SetEntriesInAclW(ACECount, mem.AddrOfPinnedObject(), oldAcl, out newAcl);

                if (err != NativeMethods.ERROR_SUCCESS)
                {
                    throw new Win32Exception(err);
                }
            }
            finally
            {
                mem.Free();

                for (int i = 0; i < ACECount; i++)
                {
                    if (entries[i].data != 0)
                    {
                        Marshal.FreeHGlobal(entries[i].data);
                    }
                }
            }


            return newAcl;
        }

        internal static void FreeAcl(IntPtr acl)
        {
            SafeNativeMethods.LocalFree(acl);
        }
    }
}
