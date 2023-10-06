//------------------------------------------------------------------------------
// <copyright file="IMessageFormatter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;

    /// <devdoc>
    ///    The functions defined in this interface are used to
    ///    serialize and deserialize objects into and from
    ///    MessageQueue messages.
    /// </devdoc>
    interface IMessageFormatter : ICloneable
    {

        /// <devdoc>
        ///    When this method is called, the formatter will attempt to determine
        ///    if the contents of the message are something the formatter can deal with.
        /// </devdoc>
        bool CanRead(Message message);

        /// <devdoc>
        ///    This method is used to read the contents from the given message
        ///     and create an object.
        /// </devdoc>
        object Read(Message message);

        /// <devdoc>
        ///    This method is used to write the given object into the given message.
        ///     If the formatter cannot understand the given object, an exception is thrown.
        /// </devdoc>
        void Write(Message message, object obj);
    }
}
