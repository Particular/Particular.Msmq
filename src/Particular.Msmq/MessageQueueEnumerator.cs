//------------------------------------------------------------------------------
// <copyright file="MessageQueueEnumerator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>Provides (forward-only) cursor semantics to enumerate the queues on a
    ///       computer.</para>
    ///    <note type="rnotes">
    ///       I'm assuming all the queues have to
    ///       be
    ///       on the same computer. Is this the case? Do we want to translate this reference
    ///       to "cursor semantics" into English, or is it okay as it stands? Will the users
    ///       understand the concept of a cursor?
    ///    </note>
    /// </devdoc>
    class MessageQueueEnumerator : MarshalByRefObject, IEnumerator, IDisposable
    {
        readonly MessageQueueCriteria criteria;
        LocatorHandle locatorHandle = Interop.LocatorHandle.InvalidHandle;
        bool disposed;

        /// <internalonly/>
        internal MessageQueueEnumerator(MessageQueueCriteria criteria)
        {
            this.criteria = criteria;
        }

        /// <devdoc>
        ///     Returns the current MessageQueue of the  enumeration.
        ///     Before the first call to MoveNext and following a call to MoveNext that
        ///     returned false an InvalidOperationException will be thrown. Multiple
        ///     calls to Current with no intervening calls to MoveNext will return the
        ///     same MessageQueue object.
        /// </devdoc>
        public MessageQueue Current
        {
            private set;
            get
            {
                if (field == null)
                {
                    throw new InvalidOperationException(Res.GetString(Res.NoCurrentMessageQueue));
                }

                return field;
            }
        }

        /// <internalonly/>
        object IEnumerator.Current => Current;

        /// <devdoc>
        ///    <para>Frees the managed resources associated with the enumerator.</para>
        /// </devdoc>
        public void Close()
        {
            if (!locatorHandle.IsInvalid)
            {
                locatorHandle.Close();
                Current = null;
            }
        }

        /// <devdoc>
        /// </devdoc>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <devdoc>
        ///    <para>
        ///    </para>
        /// </devdoc>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
            }

            disposed = true;
        }

        /// <devdoc>
        ///    <para>Indicates the native Message Queuing handle used to locate queues in a network. This
        ///       property is read-only.</para>
        /// </devdoc>
        public IntPtr LocatorHandle => Handle.DangerousGetHandle();

        LocatorHandle Handle
        {
            get
            {
                if (locatorHandle.IsInvalid)
                {
                    //Cannot allocate the locatorHandle if the object has been disposed, since finalization has been suppressed.
                    ObjectDisposedException.ThrowIf(disposed, GetType().Name);

                    Columns columns = new(2);
                    LocatorHandle enumHandle;
                    columns.AddColumnId(NativeMethods.QUEUE_PROPID_PATHNAME);
                    //Adding the instance property avoids accessing the DS a second
                    //time, the formatName can be resolved by calling MQInstanceToFormatName
                    columns.AddColumnId(NativeMethods.QUEUE_PROPID_INSTANCE);
                    int status;
                    if (criteria != null)
                    {
                        status = UnsafeNativeMethods.MQLocateBegin(null, criteria.Reference, columns.GetColumnsRef(), out enumHandle);
                    }
                    else
                    {
                        status = UnsafeNativeMethods.MQLocateBegin(null, null, columns.GetColumnsRef(), out enumHandle);
                    }

                    if (MessageQueue.IsFatalError(status))
                    {
                        throw new MessageQueueException(status);
                    }

                    locatorHandle = enumHandle;
                }

                return locatorHandle;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Advances the enumerator to the next queue of the enumeration, if one
        ///       is currently available.</para>
        /// </devdoc>
        public bool MoveNext()
        {
            var array = new MQPROPVARIANTS[2];
            int propertyCount;
            string currentItem;
            byte[] currentGuid = new byte[16];
            string machineName = null;

            if (criteria != null && criteria.FilterMachine)
            {
                if (criteria.MachineName.CompareTo(".") == 0)
                {
                    machineName = MessageQueue.ComputerName + "\\";
                }
                else
                {
                    machineName = criteria.MachineName + "\\";
                }
            }

            do
            {
                propertyCount = 2;
                int status;
                status = SafeNativeMethods.MQLocateNext(Handle, ref propertyCount, array);
                if (MessageQueue.IsFatalError(status))
                {
                    throw new MessageQueueException(status);
                }

                if (propertyCount != 2)
                {
                    Current = null;
                    return false;
                }

                //Using Unicode API even on Win9x
                currentItem = Marshal.PtrToStringUni(array[0].ptr);
                Marshal.Copy(array[1].ptr, currentGuid, 0, 16);
                //MSMQ allocated this memory, lets free it.
                SafeNativeMethods.MQFreeMemory(array[0].ptr);
                SafeNativeMethods.MQFreeMemory(array[1].ptr);
            }
            while (machineName != null && (machineName.Length >= currentItem.Length ||
                                           string.Compare(machineName, 0, currentItem, 0, machineName.Length, true, CultureInfo.InvariantCulture) != 0));

            Current = new MessageQueue(currentItem, new Guid(currentGuid));
            return true;
        }

        /// <devdoc>
        ///    <para>Resets the cursor, so it points to the head of the list..</para>
        /// </devdoc>
        public void Reset()
        {
            Close();
        }
    }
}
