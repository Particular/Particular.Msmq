//------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    /// <devdoc>
    ///    A message can be a normal MSMQ message, a positive or negative
    ///    (arrival and read) acknowledgment message, or a report message.
    /// </devdoc>
    enum MessageType
    {
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Acknowledgment = 1,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Normal = 2,
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        Report = 3,
    }
}
