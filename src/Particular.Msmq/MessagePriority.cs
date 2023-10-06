//------------------------------------------------------------------------------
// <copyright file="MessagePriority.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    /// <devdoc>
    ///    Message priority effects how MSMQ handles the message while it is in route,
    ///    as well as where the message is placed in the queue. Higher priority messages
    ///    are given preference during routing, and inserted toward the front of the queue.
    ///    Messages with the same priority are placed in the queue according to their arrival
    ///    time.
    /// </devdoc>
    enum MessagePriority
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Lowest = 0,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        VeryLow = 1,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Low = 2,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Normal = 3,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        AboveNormal = 4,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        High = 5,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        VeryHigh = 6,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Highest = 7,
    }
}
