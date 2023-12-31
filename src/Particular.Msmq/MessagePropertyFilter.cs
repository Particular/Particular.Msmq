//------------------------------------------------------------------------------
// <copyright file="MessagePropertyFilter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    ///    <para>
    ///       Limits the
    ///       properties retrieved when receiving messages from a queue.
    ///    </para>
    /// </devdoc>
    class MessagePropertyFilter : ICloneable
    {
        internal const int ACKNOWLEDGEMENT = 1;
        internal const int ACKNOWLEDGE_TYPE = 1 << 2;
        internal const int ADMIN_QUEUE = 1 << 3;
        internal const int BODY = 1 << 4;
        internal const int LABEL = 1 << 5;
        internal const int ID = 1 << 6;
        internal const int USE_DEADLETTER_QUEUE = 1 << 7;
        internal const int RESPONSE_QUEUE = 1 << 8;
        internal const int MESSAGE_TYPE = 1 << 9;
        internal const int USE_JOURNALING = 1 << 10;
        internal const int LOOKUP_ID = 1 << 11;

        internal const int APP_SPECIFIC = 1;
        internal const int ARRIVED_TIME = 1 << 2;
        internal const int ATTACH_SENDER_ID = 1 << 3;
        internal const int AUTHENTICATED = 1 << 4;
        internal const int CONNECTOR_TYPE = 1 << 5;
        internal const int CORRELATION_ID = 1 << 6;
        internal const int CRYPTOGRAPHIC_PROVIDER_NAME = 1 << 7;
        internal const int CRYPTOGRAPHIC_PROVIDER_TYPE = 1 << 8;
        internal const int IS_RECOVERABLE = 1 << 9;
        internal const int DIGITAL_SIGNATURE = 1 << 10;
        internal const int ENCRYPTION_ALGORITHM = 1 << 11;
        internal const int EXTENSION = 1 << 12;
        internal const int FOREIGN_ADMIN_QUEUE = 1 << 13;
        internal const int HASH_ALGORITHM = 1 << 14;
        internal const int DESTINATION_QUEUE = 1 << 15;
        internal const int PRIORITY = 1 << 16;
        internal const int SECURITY_CONTEXT = 1 << 17;
        internal const int SENDER_CERTIFICATE = 1 << 18;
        internal const int SENDER_ID = 1 << 19;
        internal const int SENT_TIME = 1 << 20;
        internal const int SOURCE_MACHINE = 1 << 21;
        internal const int SYMMETRIC_KEY = 1 << 22;
        internal const int TIME_TO_BE_RECEIVED = 1 << 23;
        internal const int TIME_TO_REACH_QUEUE = 1 << 24;
        internal const int USE_AUTHENTICATION = 1 << 25;
        internal const int USE_ENCRYPTION = 1 << 26;
        internal const int USE_TRACING = 1 << 27;
        internal const int VERSION = 1 << 28;
        internal const int IS_FIRST_IN_TRANSACTION = 1 << 29;
        internal const int IS_LAST_IN_TRANSACTION = 1 << 30;
        internal const int TRANSACTION_ID = 1 << 31;

        internal int data1;
        internal int data2;
        const int defaultBodySize = 1024;
        const int defaultExtensionSize = 255;
        const int defaultLabelSize = 255;
        internal int bodySize = defaultBodySize;
        internal int extensionSize = defaultExtensionSize;
        internal int labelSize = defaultLabelSize;


        /// <devdoc>
        ///    <para>
        ///       Initializes a new instance of the <see cref='MessagePropertyFilter'/>
        ///       class
        ///       and
        ///       sets
        ///       the
        ///       most
        ///       common
        ///       filter
        ///       properties
        ///       to
        ///       true.
        ///    </para>
        /// </devdoc>
        public MessagePropertyFilter()
        {
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve
        ///    <see cref='Message.Acknowledgment' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool Acknowledgment
        {
            get
            {
                return (data1 & ACKNOWLEDGEMENT) != 0;
            }

            set
            {
                data1 = value ? data1 | ACKNOWLEDGEMENT : data1 & ~ACKNOWLEDGEMENT;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.AcknowledgeType' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool AcknowledgeType
        {
            get
            {
                return (data1 & ACKNOWLEDGE_TYPE) != 0;
            }

            set
            {
                data1 = value ? data1 | ACKNOWLEDGE_TYPE : data1 & ~ACKNOWLEDGE_TYPE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.AdministrationQueue' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool AdministrationQueue
        {
            get
            {
                return (data1 & ADMIN_QUEUE) != 0;
            }

            set
            {
                data1 = value ? data1 | ADMIN_QUEUE : data1 & ~ADMIN_QUEUE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.AppSpecific' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool AppSpecific
        {
            get
            {
                return (data2 & APP_SPECIFIC) != 0;
            }

            set
            {
                data2 = value ? data2 | APP_SPECIFIC : data2 & ~APP_SPECIFIC;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.ArrivedTime' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool ArrivedTime
        {
            get
            {
                return (data2 & ARRIVED_TIME) != 0;
            }

            set
            {
                data2 = value ? data2 | ARRIVED_TIME : data2 & ~ARRIVED_TIME;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.AttachSenderId' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool AttachSenderId
        {
            get
            {
                return (data2 & ATTACH_SENDER_ID) != 0;
            }

            set
            {
                data2 = value ? data2 | ATTACH_SENDER_ID : data2 & ~ATTACH_SENDER_ID;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.Authenticated' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool Authenticated
        {
            get
            {
                return (data2 & AUTHENTICATED) != 0;
            }

            set
            {
                data2 = value ? data2 | AUTHENTICATED : data2 & ~AUTHENTICATED;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.AuthenticationProviderName' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool AuthenticationProviderName
        {
            get
            {
                return (data2 & CRYPTOGRAPHIC_PROVIDER_NAME) != 0;
            }

            set
            {
                data2 = value ? data2 | CRYPTOGRAPHIC_PROVIDER_NAME : data2 & ~CRYPTOGRAPHIC_PROVIDER_NAME;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.AuthenticationProviderType' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool AuthenticationProviderType
        {
            get
            {
                return (data2 & CRYPTOGRAPHIC_PROVIDER_TYPE) != 0;
            }

            set
            {
                data2 = value ? data2 | CRYPTOGRAPHIC_PROVIDER_TYPE : data2 & ~CRYPTOGRAPHIC_PROVIDER_TYPE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.Body' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool Body
        {
            get
            {
                return (data1 & BODY) != 0;
            }

            set
            {
                data1 = value ? data1 | BODY : data1 & ~BODY;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.ConnectorType' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool ConnectorType
        {
            get
            {
                return (data2 & CONNECTOR_TYPE) != 0;
            }

            set
            {
                data2 = value ? data2 | CONNECTOR_TYPE : data2 & ~CONNECTOR_TYPE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.CorrelationId' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool CorrelationId
        {
            get
            {
                return (data2 & CORRELATION_ID) != 0;
            }

            set
            {
                data2 = value ? data2 | CORRELATION_ID : data2 & ~CORRELATION_ID;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets
        ///       or sets the size,
        ///       in bytes, of the default body buffer.
        ///    </para>
        /// </devdoc>
        public int DefaultBodySize
        {
            get
            {
                return bodySize;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Res.GetString(Res.DefaultSizeError));
                }

                bodySize = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets
        ///       or sets the
        ///       size, in bytes, of the default extension buffer.
        ///    </para>
        /// </devdoc>
        public int DefaultExtensionSize
        {
            get
            {
                return extensionSize;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Res.GetString(Res.DefaultSizeError));
                }

                extensionSize = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets
        ///       or sets the size,
        ///       in bytes, of the default label buffer.
        ///    </para>
        /// </devdoc>
        public int DefaultLabelSize
        {
            get
            {
                return labelSize;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Res.GetString(Res.DefaultSizeError));
                }

                labelSize = value;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.DestinationQueue' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool DestinationQueue
        {
            get
            {
                return (data2 & DESTINATION_QUEUE) != 0;
            }

            set
            {
                data2 = value ? data2 | DESTINATION_QUEUE : data2 & ~DESTINATION_QUEUE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve
        ///    <see cref='Message.DestinationSymmetricKey' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool DestinationSymmetricKey
        {
            get
            {
                return (data2 & SYMMETRIC_KEY) != 0;
            }

            set
            {
                data2 = value ? data2 | SYMMETRIC_KEY : data2 & ~SYMMETRIC_KEY;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.DigitalSignature' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool DigitalSignature
        {
            get
            {
                return (data2 & DIGITAL_SIGNATURE) != 0;
            }

            set
            {
                data2 = value ? data2 | DIGITAL_SIGNATURE : data2 & ~DIGITAL_SIGNATURE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.EncryptionAlgorithm' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool EncryptionAlgorithm
        {
            get
            {
                return (data2 & ENCRYPTION_ALGORITHM) != 0;
            }

            set
            {
                data2 = value ? data2 | ENCRYPTION_ALGORITHM : data2 & ~ENCRYPTION_ALGORITHM;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.Extension' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool Extension
        {
            get
            {
                return (data2 & EXTENSION) != 0;
            }

            set
            {
                data2 = value ? data2 | EXTENSION : data2 & ~EXTENSION;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.HashAlgorithm' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool HashAlgorithm
        {
            get
            {
                return (data2 & HASH_ALGORITHM) != 0;
            }

            set
            {
                data2 = value ? data2 | HASH_ALGORITHM : data2 & ~HASH_ALGORITHM;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.Id' qualify='true'/>
        ///       property information when receiving or peeking a message.
        ///    </para>
        /// </devdoc>
        public bool Id
        {
            get
            {
                return (data1 & ID) != 0;
            }

            set
            {
                data1 = value ? data1 | ID : data1 & ~ID;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.IsFirstInTransaction' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool IsFirstInTransaction
        {
            get
            {
                return (data2 & IS_FIRST_IN_TRANSACTION) != 0;
            }

            set
            {
                data2 = value ? data2 | IS_FIRST_IN_TRANSACTION : data2 & ~IS_FIRST_IN_TRANSACTION;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.IsLastInTransaction' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool IsLastInTransaction
        {
            get
            {
                return (data2 & IS_LAST_IN_TRANSACTION) != 0;
            }

            set
            {
                data2 = value ? data2 | IS_LAST_IN_TRANSACTION : data2 & ~IS_LAST_IN_TRANSACTION;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.Label' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool Label
        {
            get
            {
                return (data1 & LABEL) != 0;
            }

            set
            {
                data1 = value ? data1 | LABEL : data1 & ~LABEL;
            }
        }


        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.LookupId' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool LookupId
        {
            get
            {
                if (!MessageQueue.Msmq3OrNewer)
                {
                    throw new PlatformNotSupportedException(Res.GetString(Res.PlatformNotSupported));
                }

                return (data1 & LOOKUP_ID) != 0;
            }

            set
            {
                if (!MessageQueue.Msmq3OrNewer)
                {
                    throw new PlatformNotSupportedException(Res.GetString(Res.PlatformNotSupported));
                }

                data1 = value ? data1 | LOOKUP_ID : data1 & ~LOOKUP_ID;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.MessageType' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool MessageType
        {
            get
            {
                return (data1 & MESSAGE_TYPE) != 0;
            }

            set
            {
                data1 = value ? data1 | MESSAGE_TYPE : data1 & ~MESSAGE_TYPE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.Priority' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool Priority
        {
            get
            {
                return (data2 & PRIORITY) != 0;
            }

            set
            {
                data2 = value ? data2 | PRIORITY : data2 & ~PRIORITY;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.Recoverable' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool Recoverable
        {
            get
            {
                return (data2 & IS_RECOVERABLE) != 0;
            }

            set
            {
                data2 = value ? data2 | IS_RECOVERABLE : data2 & ~IS_RECOVERABLE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.ResponseQueue' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool ResponseQueue
        {
            get
            {
                return (data1 & RESPONSE_QUEUE) != 0;
            }

            set
            {
                data1 = value ? data1 | RESPONSE_QUEUE : data1 & ~RESPONSE_QUEUE;
            }
        }

        // SecurityContext is send-only property, so there's no point in
        // publicly exposing it in the filter
        internal bool SecurityContext
        {
            get
            {
                return (data2 & SECURITY_CONTEXT) != 0;
            }

            set
            {
                data2 = value ? data2 | SECURITY_CONTEXT : data2 & ~SECURITY_CONTEXT;
            }
        }


        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.SenderCertificate' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool SenderCertificate
        {
            get
            {
                return (data2 & SENDER_CERTIFICATE) != 0;
            }

            set
            {
                data2 = value ? data2 | SENDER_CERTIFICATE : data2 & ~SENDER_CERTIFICATE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.SenderId' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool SenderId
        {
            get
            {
                return (data2 & SENDER_ID) != 0;
            }

            set
            {
                data2 = value ? data2 | SENDER_ID : data2 & ~SENDER_ID;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.SenderVersion' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool SenderVersion
        {
            get
            {
                return (data2 & VERSION) != 0;
            }

            set
            {
                data2 = value ? data2 | VERSION : data2 & ~VERSION;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.SentTime' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool SentTime
        {
            get
            {
                return (data2 & SENT_TIME) != 0;
            }

            set
            {
                data2 = value ? data2 | SENT_TIME : data2 & ~SENT_TIME;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.SourceMachine' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool SourceMachine
        {
            get
            {
                return (data2 & SOURCE_MACHINE) != 0;
            }

            set
            {
                data2 = value ? data2 | SOURCE_MACHINE : data2 & ~SOURCE_MACHINE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.TimeToBeReceived' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool TimeToBeReceived
        {
            get
            {
                return (data2 & TIME_TO_BE_RECEIVED) != 0;
            }

            set
            {
                data2 = value ? data2 | TIME_TO_BE_RECEIVED : data2 & ~TIME_TO_BE_RECEIVED;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.TimeToReachQueue' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool TimeToReachQueue
        {
            get
            {
                return (data2 & TIME_TO_REACH_QUEUE) != 0;
            }

            set
            {
                data2 = value ? data2 | TIME_TO_REACH_QUEUE : data2 & ~TIME_TO_REACH_QUEUE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.TransactionId' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool TransactionId
        {
            get
            {
                return (data2 & TRANSACTION_ID) != 0;
            }

            set
            {
                data2 = value ? data2 | TRANSACTION_ID : data2 & ~TRANSACTION_ID;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.TransactionStatusQueue' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool TransactionStatusQueue
        {
            get
            {
                return (data2 & FOREIGN_ADMIN_QUEUE) != 0;
            }

            set
            {
                data2 = value ? data2 | FOREIGN_ADMIN_QUEUE : data2 & ~FOREIGN_ADMIN_QUEUE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.UseAuthentication' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool UseAuthentication
        {
            get
            {
                return (data2 & USE_AUTHENTICATION) != 0;
            }

            set
            {
                data2 = value ? data2 | USE_AUTHENTICATION : data2 & ~USE_AUTHENTICATION;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.UseDeadLetterQueue' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool UseDeadLetterQueue
        {
            get
            {
                return (data1 & USE_DEADLETTER_QUEUE) != 0;
            }

            set
            {
                data1 = value ? data1 | USE_DEADLETTER_QUEUE : data1 & ~USE_DEADLETTER_QUEUE;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.UseEncryption' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool UseEncryption
        {
            get
            {
                return (data2 & USE_ENCRYPTION) != 0;
            }

            set
            {
                data2 = value ? data2 | USE_ENCRYPTION : data2 & ~USE_ENCRYPTION;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.UseJournalQueue' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool UseJournalQueue
        {
            get
            {
                return (data1 & USE_JOURNALING) != 0;
            }

            set
            {
                data1 = value ? data1 | USE_JOURNALING : data2 & ~USE_JOURNALING;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Gets or sets a value indicating whether to retrieve <see cref='Message.UseTracing' qualify='true'/> property information when receiving or peeking
        ///       a message.
        ///    </para>
        /// </devdoc>
        public bool UseTracing
        {
            get
            {
                return (data2 & USE_TRACING) != 0;
            }

            set
            {
                data2 = value ? data2 | USE_TRACING : data2 & ~USE_TRACING;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Specifies not to retrieve
        ///       any message properties when receiving a message.
        ///    </para>
        /// </devdoc>
        public void ClearAll()
        {
            data1 = 0;
            data2 = 0;
        }

        /// <devdoc>
        ///    <para>
        ///       Filters on the message properties that the
        ///       constructor sets to <see langword='true'/>
        ///       .
        ///    </para>
        /// </devdoc>
        public void SetDefaults()
        {
            data1 = ACKNOWLEDGEMENT |
                   ACKNOWLEDGE_TYPE |
                   ADMIN_QUEUE |
                   BODY |
                   ID |
                   LABEL |
                   USE_DEADLETTER_QUEUE |
                   RESPONSE_QUEUE |
                   MESSAGE_TYPE |
                   USE_JOURNALING |
                   LOOKUP_ID;

            data2 = 0;
            DefaultBodySize = defaultBodySize;
            DefaultExtensionSize = defaultExtensionSize;
            DefaultLabelSize = defaultLabelSize;
        }

        /// <devdoc>
        ///    <para>
        ///       Specifies to retrieve all
        ///       message properties when receiving a message.
        ///    </para>
        /// </devdoc>
        public void SetAll()
        {
            data1 = ACKNOWLEDGEMENT |
                   ACKNOWLEDGE_TYPE |
                   ADMIN_QUEUE |
                   BODY |
                   ID |
                   LABEL |
                   USE_DEADLETTER_QUEUE |
                   RESPONSE_QUEUE |
                   MESSAGE_TYPE |
                   USE_JOURNALING |
                   LOOKUP_ID;

            data2 = APP_SPECIFIC |
                   ARRIVED_TIME |
                   ATTACH_SENDER_ID |
                   AUTHENTICATED |
                   CONNECTOR_TYPE |
                   CORRELATION_ID |
                   CRYPTOGRAPHIC_PROVIDER_NAME |
                   CRYPTOGRAPHIC_PROVIDER_TYPE |
                   IS_RECOVERABLE |
                   DESTINATION_QUEUE |
                   DIGITAL_SIGNATURE |
                   ENCRYPTION_ALGORITHM |
                   EXTENSION |
                   FOREIGN_ADMIN_QUEUE |
                   HASH_ALGORITHM |
                   PRIORITY |
                   SECURITY_CONTEXT |
                   SENDER_CERTIFICATE |
                   SENDER_ID |
                   SENT_TIME |
                   SOURCE_MACHINE |
                   SYMMETRIC_KEY |
                   TIME_TO_BE_RECEIVED |
                   TIME_TO_REACH_QUEUE |
                   USE_AUTHENTICATION |
                   USE_ENCRYPTION |
                   USE_TRACING |
                   VERSION |
                   IS_FIRST_IN_TRANSACTION |
                   IS_LAST_IN_TRANSACTION |
                   TRANSACTION_ID;
        }


        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}

