//------------------------------------------------------------------------------
// <copyright file="MessageLookupAction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using Particular.Msmq.Interop;

    public enum PeekAction
    {
        Current = NativeMethods.QUEUE_ACTION_PEEK_CURRENT,

        Next = NativeMethods.QUEUE_ACTION_PEEK_NEXT
    }
}
