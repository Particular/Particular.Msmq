//------------------------------------------------------------------------------
// <copyright file="AcknowledgeTypes.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>
    ///       Specifies what kind of acknowledgment to get after sending a message.
    ///    </para>
    /// </devdoc>
    [Flags]
    enum AcknowledgeTypes
    {

        /// <devdoc>
        ///    <para>
        ///       Use this value to request a positive acknowledgment when the message
        ///       reaches the queue.
        ///    </para>
        /// </devdoc>
        PositiveArrival = NativeMethods.ACKNOWLEDGE_POSITIVE_ARRIVAL,

        /// <devdoc>
        ///    <para>
        ///       Use this value to request a positive acknowledgment when the message
        ///       is successfully retrieved from the queue.
        ///    </para>
        /// </devdoc>
        PositiveReceive = NativeMethods.ACKNOWLEDGE_POSITIVE_RECEIVE,

        /// <devdoc>
        ///    <para>
        ///       Use this value to request a negative acknowledgment when the message fails
        ///       to be retrieved from the queue.
        ///    </para>
        /// </devdoc>
        NegativeReceive = NativeMethods.ACKNOWLEDGE_NEGATIVE_RECEIVE,

        /// <devdoc>
        ///    <para>
        ///       Use this value to request no acknowledgment messages (positive or negative) to be posted.
        ///    </para>
        /// </devdoc>
        None = NativeMethods.ACKNOWLEDGE_NONE,

        /// <devdoc>
        ///    <para>
        ///       Use this value to request a negative acknowledgment when the message cannot
        ///       reach the queue. This can happen when the time-to-reach-queue
        ///       timer expires, or a message cannot be authenticated.
        ///    </para>
        /// </devdoc>
        NotAcknowledgeReachQueue = NativeMethods.ACKNOWLEDGE_NEGATIVE_ARRIVAL,

        /// <devdoc>
        ///    <para>
        ///       Use this value to request a negative acknowledgment when an error occurs and
        ///       the message cannot be retrieved from the queue before its
        ///       time-to-be-received timer expires.
        ///    </para>
        /// </devdoc>
        NotAcknowledgeReceive = NegativeReceive |
                                                       NativeMethods.ACKNOWLEDGE_NEGATIVE_ARRIVAL,

        /// <devdoc>
        ///    <para>
        ///       Use this value
        ///       to request full acknowledgment (positive or negative) depending
        ///       on whether or not the message reaches the queue.
        ///       This can happen when the time-to-reach-queue timer expires,
        ///       or a message cannot be authenticated.
        ///    </para>
        /// </devdoc>
        FullReachQueue = NotAcknowledgeReachQueue |
                                        PositiveArrival,

        /// <devdoc>
        ///    <para>
        ///       Use this value to request full acknowledgment (positive or negative) depending
        ///       on whether or not the message is retrieved from the queue
        ///       before its time-to-be-received timer expires.
        ///    </para>
        /// </devdoc>
        FullReceive = NotAcknowledgeReceive |
                                PositiveReceive,

    }
}
