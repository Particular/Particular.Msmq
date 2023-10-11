//------------------------------------------------------------------------------
// <copyright file="DefaultPropertiesToSend.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    ///    <para>
    ///       Specifies the default property values that will be used when
    ///       sending objects using the message queue.
    ///    </para>
    /// </devdoc>
    class DefaultPropertiesToSend
    {
        readonly bool designMode;
        MessageQueue cachedAdminQueue;
        MessageQueue cachedResponseQueue;
        MessageQueue cachedTransactionStatusQueue;


        /// <devdoc>
        ///    <para>
        ///       Initializes a new instance of the <see cref='DefaultPropertiesToSend'/>
        ///       class.
        ///    </para>
        /// </devdoc>
        public DefaultPropertiesToSend()
        {
        }

        /// <internalonly/>
        internal DefaultPropertiesToSend(bool designMode)
        {
            this.designMode = designMode;
        }

        /// <devdoc>
        ///    <para>
        ///       Gets
        ///       or sets the type of acknowledgement message to be returned to the sending
        ///       application.
        ///    </para>
        /// </devdoc>
        public AcknowledgeTypes AcknowledgeType
        {
            get
            {
                return CachedMessage.AcknowledgeType;
            }

            set
            {
                CachedMessage.AcknowledgeType = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the queue used for acknowledgement messages
        ///       generated by the application. This is the queue that
        ///       will receive the acknowledgment message for the message you are about to
        ///       send.
        ///    </para>
        /// </devdoc>
        public MessageQueue AdministrationQueue
        {
            get
            {
                if (designMode)
                {
                    if (cachedAdminQueue != null && cachedAdminQueue.Site == null)
                    {
                        cachedAdminQueue = null;
                    }

                    return cachedAdminQueue;
                }

                return CachedMessage.AdministrationQueue;
            }

            set
            {
                //The format name of this queue shouldn't be
                //resolved at desgin time, but it should at runtime.
                if (designMode)
                {
                    cachedAdminQueue = value;
                }
                else
                {
                    CachedMessage.AdministrationQueue = value;
                }
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets application-generated information.
        ///
        ///    </para>
        /// </devdoc>
        public int AppSpecific
        {
            get
            {
                return CachedMessage.AppSpecific;
            }

            set
            {
                CachedMessage.AppSpecific = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating if the sender ID is to be attached to the
        ///       message.
        ///
        ///    </para>
        /// </devdoc>
        public bool AttachSenderId
        {
            get
            {
                return CachedMessage.AttachSenderId;
            }

            set
            {
                CachedMessage.AttachSenderId = value;
            }
        }

        /// <internalonly/>
        internal Message CachedMessage { get; } = new();

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the encryption algorithm used to encrypt the body of a
        ///       private message.
        ///
        ///    </para>
        /// </devdoc>
        public EncryptionAlgorithm EncryptionAlgorithm
        {
            get
            {
                return CachedMessage.EncryptionAlgorithm;
            }

            set
            {
                CachedMessage.EncryptionAlgorithm = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets additional information associated with the message.
        ///
        ///    </para>
        /// </devdoc>
        public byte[] Extension
        {
            get
            {
                return CachedMessage.Extension;
            }

            set
            {
                CachedMessage.Extension = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the hashing algorithm used when
        ///       authenticating
        ///       messages.
        ///
        ///    </para>
        /// </devdoc>
        public HashAlgorithm HashAlgorithm
        {
            get
            {
                return CachedMessage.HashAlgorithm;
            }

            set
            {
                CachedMessage.HashAlgorithm = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the message label.
        ///
        ///    </para>
        /// </devdoc>
        public string Label
        {
            get
            {
                return CachedMessage.Label;
            }

            set
            {
                CachedMessage.Label = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the message priority.
        ///    </para>
        /// </devdoc>
        public MessagePriority Priority
        {
            get
            {
                return CachedMessage.Priority;
            }

            set
            {
                CachedMessage.Priority = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether the message is
        ///       guaranteed to be delivered in the event
        ///       of a computer failure or network problem.
        ///
        ///    </para>
        /// </devdoc>
        public bool Recoverable
        {
            get
            {
                return CachedMessage.Recoverable;
            }

            set
            {
                CachedMessage.Recoverable = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the queue which receives application-generated response
        ///       messages.
        ///
        ///    </para>
        /// </devdoc>
        public MessageQueue ResponseQueue
        {
            get
            {
                if (designMode)
                {
                    return cachedResponseQueue;
                }

                return CachedMessage.ResponseQueue;
            }

            set
            {
                //The format name of this queue shouldn't be
                //resolved at desgin time, but it should at runtime.
                if (designMode)
                {
                    cachedResponseQueue = value;
                }
                else
                {
                    CachedMessage.ResponseQueue = value;
                }
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the time limit for the message to be
        ///       retrieved from
        ///       the target queue.
        ///    </para>
        /// </devdoc>
        public TimeSpan TimeToBeReceived
        {
            get
            {
                return CachedMessage.TimeToBeReceived;
            }

            set
            {
                CachedMessage.TimeToBeReceived = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets the time limit for the message to
        ///       reach the queue.
        ///
        ///    </para>
        /// </devdoc>
        public TimeSpan TimeToReachQueue
        {
            get
            {
                return CachedMessage.TimeToReachQueue;
            }

            set
            {
                CachedMessage.TimeToReachQueue = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets the transaction status queue on the source computer.
        ///
        ///    </para>
        /// </devdoc>
        public MessageQueue TransactionStatusQueue
        {
            get
            {
                if (designMode)
                {
                    return cachedTransactionStatusQueue;
                }

                return CachedMessage.TransactionStatusQueue;
            }

            set
            {
                //The format name of this queue shouldn't be
                //resolved at desgin time, but it should at runtime.
                if (designMode)
                {
                    cachedTransactionStatusQueue = value;
                }
                else
                {
                    CachedMessage.TransactionStatusQueue = value;
                }
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether the message must be authenticated.
        ///    </para>
        /// </devdoc>
        public bool UseAuthentication
        {
            get
            {
                return CachedMessage.UseAuthentication;
            }

            set
            {
                CachedMessage.UseAuthentication = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether a copy of the message that could not
        ///       be delivered should be sent to a dead-letter queue.
        ///    </para>
        /// </devdoc>
        public bool UseDeadLetterQueue
        {
            get
            {
                return CachedMessage.UseDeadLetterQueue;
            }

            set
            {
                CachedMessage.UseDeadLetterQueue = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to encrypt private messages.
        ///    </para>
        /// </devdoc>
        public bool UseEncryption
        {
            get
            {
                return CachedMessage.UseEncryption;
            }

            set
            {
                CachedMessage.UseEncryption = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether a copy of the message should be kept
        ///       in a machine journal on the originating computer.
        ///    </para>
        /// </devdoc>
        public bool UseJournalQueue
        {
            get
            {
                return CachedMessage.UseJournalQueue;
            }

            set
            {
                CachedMessage.UseJournalQueue = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to trace a message as it moves toward
        ///       its destination queue.
        ///    </para>
        /// </devdoc>
        public bool UseTracing
        {
            get
            {
                return CachedMessage.UseTracing;
            }

            set
            {
                CachedMessage.UseTracing = value;
            }
        }

        /// <internalonly/>
        bool ShouldSerializeTimeToBeReceived()
        {
            if (TimeToBeReceived == Message.InfiniteTimeout)
            {
                return false;
            }

            return true;
        }

        /// <internalonly/>
        bool ShouldSerializeTimeToReachQueue()
        {
            if (TimeToReachQueue == Message.InfiniteTimeout)
            {
                return false;
            }

            return true;
        }

        /// <internalonly/>
        bool ShouldSerializeExtension()
        {
            if (Extension != null && Extension.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}