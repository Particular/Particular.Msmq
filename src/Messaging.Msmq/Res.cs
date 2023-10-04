namespace System.Messaging
{
    static class Res
    {
        public static string GetString(string text) => text;

        public static string GetString(string text, object input0) => string.Format(text, input0);

        public static string GetString(string text, object input0, object input1) => string.Format(text, input0, input1);

        public const string MSMQNotInstalled = "Message Queuing has not been installed on this computer.";
        public const string PlatformNotSupported = "Requested operation is not supported on this platform.";
        public const string MSMQInfoNotSupported = "Browsing private queues is not supported by the Microsoft Message Queuing(MSMQ) runtime installed on this computer.";
        public const string NotAcknowledgement = "Cannot retrieve property because the message is not an acknowledgment message.";
        public const string NoCurrentMessage = "Cursor is not currently pointing to a Message instance. It is located either before the first or after the last message in the enumeration.";
        public const string DefaultSizeError = "Size is invalid. It must be greater than or equal to zero.";
        public const string InvalidProperty = "Invalid value {1} for property {0}.";
        public const string PathSyntax = "Path syntax is invalid.";
        public const string InvalidParameter = "Invalid value {1} for parameter {0}.";
        public const string WinNTRequired = "Feature requires Windows NT.";
        public const string TooManyColumns = "Column Count limit exceeded ({0}).";
        public const string MissingProperty = "Property {0} was not retrieved when receiving the message. Ensure that the PropertyFilter is set correctly.";
        public const string InvalidTrustee = "Trustee property of an entry in the access control list is null.";
        public const string InvalidTrusteeName = "Entry in the access control list contains a trustee with an invalid name.";
        public const string ArrivedTimeNotSet = "Arrived time is undefined for this message. This message was not created by a call to the Receive method.";
        public const string CriteriaNotDefined = "Criteria property has not been defined.";
        public const string InvalidDateValue = "Date is invalid. It must be between {0} and {1}";
        public const string InvalidQueuePathToCreate = "Cannot create a queue with the path {0}.";
        public const string AsyncResultInvalid = "IAsyncResult interface passed is not valid because it was not created as a result of an asynchronous request on this object.";
        public const string QueueExistsError = "Cannot determine whether a queue with the specified format name exists.";
        public const string AmbiguousLabel = "Label \"{0}\" references more than one queue. Set the path for the desired queue.";
        public const string InvalidLabel = "Cannot find queue with label {0}.";
        public const string LongQueueName = "Queue name is too long. Size of queue name cannot exceed 255 characters.";
        public const string CouldntResolve = "Could not resolve name {0} (error = {1} ).";
        public const string AuthenticationNotSet = "Cannot determine authentication for this message. This message was not created by a call to the Receive method.";
        public const string NoCurrentMessageQueue = "Cursor is not currently pointing to a MessageQueue instance. It is located either before the first or after the last queue in the enumeration.";
        public const string TransactionNotStarted = "Cannot commit or roll back transaction because BeginTransaction has not been called.";
        public const string TypeListMissing = "Target type array is missing. The target type array must be set in order to deserialize the XML-formatted message.";
        public const string CouldntResolveName = "Could not resolve name {0}.";
        public const string FormatterMissing = "Cannot find a formatter capable of reading this message.";
        public const string DestinationQueueNotSet = "Destination queue is not defined for this message. The message was not created by a call to the Receive method.";
        public const string IdNotSet = "Unique identifier for this message is not defined. The message was not created by a call to the Receive method.";
        public const string MessageTypeNotSet = "Type is not defined for this message. The message was not created by a call to the Receive method.";
        public const string LookupIdNotSet = "Lookup identifier is not defined for this message. The message was not created by a call to the Receive method, or lookup identifier was not added to the properties to retrieve.";
        public const string SenderIdNotSet = "Sender identifier is not defined for this message. The message was not created by a call to the Receive method.";
        public const string VersionNotSet = "Message Queuing version is not defined for this message. The message was not created by a call to the Receive method.";
        public const string SentTimeNotSet = "Sent time is not defined for this message. The message was not created by a call to the Receive method.";
        public const string SourceMachineNotSet = "Source computer is not defined for this message. The message was not created by a call to the Receive method.";
        public const string InvalidId = "Identifier is not in the incorrect format.";
        public const string TransactionStarted = "Cannot start a transaction while a pending transaction exists.";
        public const string InvalidTypeDeserialization = "Cannot deserialize the message passed as an argument. Cannot recognize the serialization format.";
    }
}

