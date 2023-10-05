//------------------------------------------------------------------------------
// <copyright file="DefaultPropertiesToSend.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Messaging.Msmq
{
    using System;

    /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend"]/*' />
    /// <devdoc>
    ///    <para>
    ///       Specifies the default property values that will be used when
    ///       sending objects using the message queue.
    ///    </para>
    /// </devdoc>
    public class DefaultPropertiesToSend
    {
        private readonly Message cachedMessage = new();
        private readonly bool designMode;
        private MessageQueue cachedAdminQueue;
        private MessageQueue cachedResponseQueue;
        private MessageQueue cachedTransactionStatusQueue;


        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.DefaultPropertiesToSend"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Initializes a new instance of the <see cref='System.Messaging.DefaultPropertiesToSend'/>
        ///       class.
        ///    </para>
        /// </devdoc>
        public DefaultPropertiesToSend()
        {
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.DefaultPropertiesToSend1"]/*' />
        /// <internalonly/>
        internal DefaultPropertiesToSend(bool designMode)
        {
            this.designMode = designMode;
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.AcknowledgeTypes"]/*' />
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
                return this.cachedMessage.AcknowledgeType;
            }

            set
            {
                this.cachedMessage.AcknowledgeType = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.AdministrationQueue"]/*' />
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
                if (this.designMode)
                {
                    if (this.cachedAdminQueue != null && this.cachedAdminQueue.Site == null)
                    {
                        this.cachedAdminQueue = null;
                    }

                    return this.cachedAdminQueue;
                }

                return this.cachedMessage.AdministrationQueue;
            }

            set
            {
                //The format name of this queue shouldn't be
                //resolved at desgin time, but it should at runtime.
                if (this.designMode)
                {
                    this.cachedAdminQueue = value;
                }
                else
                {
                    this.cachedMessage.AdministrationQueue = value;
                }
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.AppSpecific"]/*' />
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
                return this.cachedMessage.AppSpecific;
            }

            set
            {
                this.cachedMessage.AppSpecific = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.AttachSenderId"]/*' />
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
                return this.cachedMessage.AttachSenderId;
            }

            set
            {
                this.cachedMessage.AttachSenderId = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.CachedMessage"]/*' />
        /// <internalonly/>
        internal Message CachedMessage
        {
            get
            {
                return this.cachedMessage;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.EncryptionAlgorithm"]/*' />
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
                return this.cachedMessage.EncryptionAlgorithm;
            }

            set
            {
                this.cachedMessage.EncryptionAlgorithm = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.Extension"]/*' />
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
                return this.cachedMessage.Extension;
            }

            set
            {
                this.cachedMessage.Extension = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.HashAlgorithm"]/*' />
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
                return this.cachedMessage.HashAlgorithm;
            }

            set
            {
                this.cachedMessage.HashAlgorithm = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.Label"]/*' />
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
                return this.cachedMessage.Label;
            }

            set
            {
                this.cachedMessage.Label = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.Priority"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Gets or sets the message priority.
        ///    </para>
        /// </devdoc>
        public MessagePriority Priority
        {
            get
            {
                return this.cachedMessage.Priority;
            }

            set
            {
                this.cachedMessage.Priority = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.Recoverable"]/*' />
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
                return this.cachedMessage.Recoverable;
            }

            set
            {
                this.cachedMessage.Recoverable = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.ResponseQueue"]/*' />
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
                if (this.designMode)
                {
                    return this.cachedResponseQueue;
                }

                return this.cachedMessage.ResponseQueue;
            }

            set
            {
                //The format name of this queue shouldn't be
                //resolved at desgin time, but it should at runtime.
                if (this.designMode)
                {
                    this.cachedResponseQueue = value;
                }
                else
                {
                    this.cachedMessage.ResponseQueue = value;
                }
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.TimeToBeReceived"]/*' />
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
                return this.cachedMessage.TimeToBeReceived;
            }

            set
            {
                this.cachedMessage.TimeToBeReceived = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.TimeToReachQueue"]/*' />
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
                return this.cachedMessage.TimeToReachQueue;
            }

            set
            {
                this.cachedMessage.TimeToReachQueue = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.TransactionStatusQueue"]/*' />
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
                if (this.designMode)
                {
                    return this.cachedTransactionStatusQueue;
                }

                return this.cachedMessage.TransactionStatusQueue;
            }

            set
            {
                //The format name of this queue shouldn't be
                //resolved at desgin time, but it should at runtime.
                if (this.designMode)
                {
                    this.cachedTransactionStatusQueue = value;
                }
                else
                {
                    this.cachedMessage.TransactionStatusQueue = value;
                }
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.UseAuthentication"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether the message must be authenticated.
        ///    </para>
        /// </devdoc>
        public bool UseAuthentication
        {
            get
            {
                return this.cachedMessage.UseAuthentication;
            }

            set
            {
                this.cachedMessage.UseAuthentication = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.UseDeadLetterQueue"]/*' />
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
                return this.cachedMessage.UseDeadLetterQueue;
            }

            set
            {
                this.cachedMessage.UseDeadLetterQueue = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.UseEncryption"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to encrypt private messages.
        ///    </para>
        /// </devdoc>
        public bool UseEncryption
        {
            get
            {
                return this.cachedMessage.UseEncryption;
            }

            set
            {
                this.cachedMessage.UseEncryption = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.UseJournalQueue"]/*' />
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
                return this.cachedMessage.UseJournalQueue;
            }

            set
            {
                this.cachedMessage.UseJournalQueue = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.UseTracing"]/*' />
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
                return this.cachedMessage.UseTracing;
            }

            set
            {
                this.cachedMessage.UseTracing = value;
            }
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.ShouldSerializeTimeToBeReceived"]/*' />
        /// <internalonly/>
        private bool ShouldSerializeTimeToBeReceived()
        {
            if (TimeToBeReceived == Message.InfiniteTimeout)
            {
                return false;
            }

            return true;
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.ShouldSerializeTimeToReachQueue"]/*' />
        /// <internalonly/>
        private bool ShouldSerializeTimeToReachQueue()
        {
            if (TimeToReachQueue == Message.InfiniteTimeout)
            {
                return false;
            }

            return true;
        }

        /// <include file='doc\DefaultPropertiesToSend.uex' path='docs/doc[@for="DefaultPropertiesToSend.ShouldSerializeExtension"]/*' />
        /// <internalonly/>
        private bool ShouldSerializeExtension()
        {
            if (Extension != null && Extension.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
