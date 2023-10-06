//------------------------------------------------------------------------------
// <copyright file="Acknowledgement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>
    ///       Specifies what went wrong (or right) during a Message
    ///       Queuing operation. This is the type of a property of an acknowledgement
    ///       message.
    ///    </para>
    /// </devdoc>
    enum Acknowledgment
    {
        /// <devdoc>
        ///    <para>
        ///       The default value of the <see cref='Acknowledgment'/>
        ///       property. This means the message is
        ///       not an acknowledgment message.
        ///    </para>
        /// </devdoc>
        None = 0,

        /// <devdoc>
        ///     The sending application does not have access rights
        ///     to the destination queue.
        /// </devdoc>
        AccessDenied = NativeMethods.MESSAGE_CLASS_ACCESS_DENIED,

        /// <devdoc>
        ///     The destination queue is not available to the sending
        ///     application.
        /// </devdoc>
        BadDestinationQueue = NativeMethods.MESSAGE_CLASS_BAD_DESTINATION_QUEUE,

        /// <devdoc>
        ///     The destination Queue Manager could not decrypt a private
        ///     (encrypted) message.
        /// </devdoc>
        BadEncryption = NativeMethods.MESSAGE_CLASS_BAD_ENCRYPTION,

        /// <devdoc>
        ///     MSMQ could not authenticate the original message. The original
        ///     message's digital signature is not valid.
        /// </devdoc>
        BadSignature = NativeMethods.MESSAGE_CLASS_BAD_SIGNATURE,

        /// <devdoc>
        ///     The source Queue Manager could not encrypt a private message.
        /// </devdoc>
        CouldNotEncrypt = NativeMethods.MESSAGE_CLASS_COULD_NOT_ENCRYPT,

        /// <devdoc>
        ///     The original message's hop count is exceeded.
        /// </devdoc>
        HopCountExceeded = NativeMethods.MESSAGE_CLASS_HOP_COUNT_EXCEEDED,

        /// <devdoc>
        ///     A transaction message was sent to a non-transaction
        ///     queue.
        /// </devdoc>
        NotTransactionalQueue = NativeMethods.MESSAGE_CLASS_NOT_TRANSACTIONAL_QUEUE,

        /// <devdoc>
        ///     A non-transaction message was sent to a transaction
        ///     queue.
        /// </devdoc>
        NotTransactionalMessage = NativeMethods.MESSAGE_CLASS_NOT_TRANSACTIONAL_MESSAGE,

        /// <devdoc>
        ///     The message was purged before reaching the destination
        ///     queue.
        /// </devdoc>
        Purged = NativeMethods.MESSAGE_CLASS_PURGED,

        /// <devdoc>
        ///     The queue was deleted before the message could be read
        ///     from the queue.
        /// </devdoc>
        QueueDeleted = NativeMethods.MESSAGE_CLASS_QUEUE_DELETED,

        /// <devdoc>
        ///     The original message's destination queue is full.
        /// </devdoc>
        QueueExceedMaximumSize = NativeMethods.MESSAGE_CLASS_QUEUE_EXCEED_QUOTA,

        /// <devdoc>
        ///     The queue was purged and the message no longer exists.
        /// </devdoc>
        QueuePurged = NativeMethods.MESSAGE_CLASS_QUEUE_PURGED,

        /// <devdoc>
        ///     The original message reached its destination queue.
        /// </devdoc>
        ReachQueue = NativeMethods.MESSAGE_CLASS_REACH_QUEUE,

        /// <devdoc>
        ///     Either the time-to-reach-queue or time-to-be-received timer
        ///     expired before the original message could reach the destination queue.
        /// </devdoc>
        ReachQueueTimeout = NativeMethods.MESSAGE_CLASS_REACH_QUEUE_TIMEOUT,

        /// <devdoc>
        ///     The original message was not removed from the queue before
        ///     its time-to-be-received timer expired.
        /// </devdoc>
        ReceiveTimeout = NativeMethods.MESSAGE_CLASS_RECEIVE_TIMEOUT,

        /// <devdoc>
        ///     The original message was retrieved by the receiving
        ///     application.
        /// </devdoc>
        Receive = NativeMethods.MESSAGE_CLASS_RECEIVE,
    }
}
