//------------------------------------------------------------------------------
// <copyright file="MessageQueueErrorCode.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{

    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    enum MessageQueueErrorCode
    {
        /// <internalonly/>
        Base = unchecked((int)0xC00E0000),
        /// <devdoc>
        ///     GenericError.
        /// </devdoc>
        Generic = unchecked((int)0xC00E0001),
        /// <internalonly/>
        Property = unchecked((int)0xC00E0002),
        /// <devdoc>
        ///     The queue is not registered in the DS.
        /// </devdoc>
        QueueNotFound = unchecked((int)0xC00E0003),
        /// <devdoc>
        ///     A queue with the same pathname is already registered.
        /// </devdoc>
        QueueExists = unchecked((int)0xC00E0005),
        /// <internalonly/>
        InvalidParameter = unchecked((int)0xC00E0006),
        /// <internalonly/>
        InvalidHandle = unchecked((int)0xC00E0007),
        /// <devdoc>
        ///     The operation was cancelled before it could be completed.
        /// </devdoc>
        OperationCanceled = unchecked((int)0xC00E0008),
        /// <devdoc>
        ///     Sharing violation. The queue is already opened for
        ///     exclusive receive.
        /// </devdoc>
        SharingViolation = unchecked((int)0xC00E0009),
        /// <devdoc>
        ///     The Message Queues service is not available.
        /// </devdoc>
        ServiceNotAvailable = unchecked((int)0xC00E000B),
        /// <devdoc>
        ///     The specified machine could not be found.
        /// </devdoc>
        MachineNotFound = unchecked((int)0xC00E000D),
        /// <internalonly/>
        IllegalSort = unchecked((int)0xC00E0010),
        /// <devdoc>
        ///     The user is an illegal user.
        /// </devdoc>
        IllegalUser = unchecked((int)0xC00E0011),
        /// <devdoc>
        ///     No connection with this site's controller(s).
        /// </devdoc>
        NoDs = unchecked((int)0xC00E0013),
        /// <devdoc>
        ///     Illegal queue path name.
        /// </devdoc>
        IllegalQueuePathName = unchecked((int)0xC00E0014),
        /// <devdoc>
        ///     Illegal property value.
        /// </devdoc>
        IllegalPropertyValue = unchecked((int)0xC00E0018),
        /// <internalonly/>
        IllegalPropertyVt = unchecked((int)0xC00E0019),
        /// <internalonly/>
        BufferOverflow = unchecked((int)0xC00E001A),
        /// <devdoc>
        ///     The Receive or Peek Message timeout has expired.
        /// </devdoc>
        IOTimeout = unchecked((int)0xC00E001B),
        /// <internalonly/>
        IllegalCursorAction = unchecked((int)0xC00E001C),
        /// <devdoc>
        ///     A message that is currently pointed at by the cursor has been removed from
        ///     the queue by another process or by another call to MQReceiveMessage
        ///     without the use of this cursor.
        /// </devdoc>
        MessageAlreadyReceived = unchecked((int)0xC00E001D),
        /// <devdoc>
        ///     The given format name is invalid.
        /// </devdoc>
        IllegalFormatName = unchecked((int)0xC00E001E),
        /// <internalonly/>
        FormatNameBufferTooSmall = unchecked((int)0xC00E001F),
        /// <devdoc>
        ///     The requested operation for the specified format name is not
        ///     supported (e.g., delete a direct queue format name).
        /// </devdoc>
        UnsupportedFormatNameOperation = unchecked((int)0xC00E0020),
        /// <internalonly/>
        IllegalSecurityDescriptor = unchecked((int)0xC00E0021),
        /// <internalonly/>
        SenderIdBufferTooSmall = unchecked((int)0xC00E0022),
        /// <internalonly/>
        SecurityDescriptorBufferTooSmall = unchecked((int)0xC00E0023),
        /// <devdoc>
        ///     The RPC server can not impersonate the client application, hence security
        ///     credentials could not be verified.
        /// </devdoc>
        CannotImpersonateClient = unchecked((int)0xC00E0024),
        /// <devdoc>
        ///     Access is denied.
        /// </devdoc>
        AccessDenied = unchecked((int)0xC00E0025),
        /// <devdoc>
        ///     Client does not have the required privileges to perform the operation.
        /// </devdoc>
        PrivilegeNotHeld = unchecked((int)0xC00E0026),
        /// <devdoc>
        ///     Insufficient resources to perform operation.
        /// </devdoc>
        InsufficientResources = unchecked((int)0xC00E0027),
        /// <internalonly/>
        UserBufferTooSmall = unchecked((int)0xC00E0028),
        /// <devdoc>
        ///     Could not store a recoverable or journal message. Message was not sent.
        /// </devdoc>
        MessageStorageFailed = unchecked((int)0xC00E002A),
        /// <internalonly/>
        SenderCertificateBufferTooSmall = unchecked((int)0xC00E002B),
        /// <devdoc>
        ///     The user certificate is not valid.
        /// </devdoc>
        InvalidCertificate = unchecked((int)0xC00E002C),
        /// <devdoc>
        ///     The internal MSMQ certificate is corrupted.
        /// </devdoc>
        CorruptedInternalCertificate = unchecked((int)0xC00E002D),
        /// <devdoc>
        ///     The internal MSMQ certificate for the user does not exist.
        /// </devdoc>
        NoInternalUserCertificate = unchecked((int)0xC00E002F),
        /// <devdoc>
        ///     A cryptogrphic function has failed.
        /// </devdoc>
        CorruptedSecurityData = unchecked((int)0xC00E0030),
        /// <devdoc>
        ///     The personal certificate store is corrupted.
        /// </devdoc>
        CorruptedPersonalCertStore = unchecked((int)0xC00E0031),
        /// <devdoc>
        ///     The computer does not support encryption operations.
        /// </devdoc>
        ComputerDoesNotSupportEncryption = unchecked((int)0xC00E0033),
        /// <internalonly/>
        BadSecurityContext = unchecked((int)0xC00E0035),
        /// <devdoc>
        ///     Could not get the SID information out of the thread token.
        /// </devdoc>
        CouldNotGetUserSid = unchecked((int)0xC00E0036),
        /// <devdoc>
        ///     Could not get the account information for the user.
        /// </devdoc>
        CouldNotGetAccountInfo = unchecked((int)0xC00E0037),
        /// <internalonly/>
        IllegalCriteriaColumns = unchecked((int)0xC00E0038),
        /// <internalonly/>
        IllegalPropertyId = unchecked((int)0xC00E0039),
        /// <internalonly/>
        IllegalRelation = unchecked((int)0xC00E003A),
        /// <internalonly/>
        IllegalPropertySize = unchecked((int)0xC00E003B),
        /// <internalonly/>
        IllegalRestrictionPropertyId = unchecked((int)0xC00E003C),
        /// <internalonly/>
        IllegalQueueProperties = unchecked((int)0xC00E003D),
        /// <devdoc>
        ///     Invalid property for the requested operation.
        /// </devdoc>
        PropertyNotAllowed = unchecked((int)0xC00E003E),
        /// <devdoc>
        ///     Not all the required properties for the operation were specified
        ///     in the input parameters.
        /// </devdoc>
        InsufficientProperties = unchecked((int)0xC00E003F),
        /// <devdoc>
        ///     Computer with the same name already exists in the site.
        /// </devdoc>
        MachineExists = unchecked((int)0xC00E0040),
        /// <internalonly/>
        IllegalMessageProperties = unchecked((int)0xC00E0041),
        /// <devdoc>
        ///     DS is full.
        /// </devdoc>
        DsIsFull = unchecked((int)0xC00E0042),
        /// <devdoc>
        ///     internal DS error.
        /// </devdoc>
        DsError = unchecked((int)0xC00E0043),
        /// <devdoc>
        ///     Invalid object owner. For example CreateQueue failed because the Queue Manager
        ///     object is invalid.
        /// </devdoc>
        InvalidOwner = unchecked((int)0xC00E0044),
        /// <devdoc>
        ///     The specified access mode is not supported.
        /// </devdoc>
        UnsupportedAccessMode = unchecked((int)0xC00E0045),
        /// <internalonly/>
        ResultBufferTooSmall = unchecked((int)0xC00E0046),
        /// <devdoc>
        ///     The Connected Network can not be deleted, it is in use.
        /// </devdoc>
        DeleteConnectedNetworkInUse = unchecked((int)0xC00E0048),
        /// <devdoc>
        ///     No response from object owner.
        /// </devdoc>
        NoResponseFromObjectServer = unchecked((int)0xC00E0049),
        /// <devdoc>
        ///     Object owner is not reachable.
        /// </devdoc>
        ObjectServerNotAvailable = unchecked((int)0xC00E004A),
        /// <devdoc>
        ///     Error while reading from a queue residing on a remote computer.
        /// </devdoc>
        QueueNotAvailable = unchecked((int)0xC00E004B),
        /// <devdoc>
        ///     Cannot connect to MS DTC.
        /// </devdoc>
        DtcConnect = unchecked((int)0xC00E004C),
        /// <devdoc>
        ///     Cannot import the transaction.
        /// </devdoc>
        TransactionImport = unchecked((int)0xC00E004E),
        /// <devdoc>
        ///     Wrong transaction usage.
        /// </devdoc>
        TransactionUsage = unchecked((int)0xC00E0050),
        /// <devdoc>
        ///     Wrong transaction operations sequence.
        /// </devdoc>
        TransactionSequence = unchecked((int)0xC00E0051),
        /// <devdoc>
        ///     Connector Type is mandatory when sending Acknowledgment or secure message.
        /// </devdoc>
        MissingConnectorType = unchecked((int)0xC00E0055),
        /// <internalonly/>
        StaleHandle = unchecked((int)0xC00E0056),
        /// <devdoc>
        ///     Cannot enlist the transaction.
        /// </devdoc>
        TransactionEnlist = unchecked((int)0xC00E0058),
        /// <devdoc>
        ///     The queue was deleted. Messages can not be received anymore using this
        ///     queue instance. The queue should be closed.
        /// </devdoc>
        QueueDeleted = unchecked((int)0xC00E005A),
        /// <devdoc>
        ///     Invalid context parameter.
        /// </devdoc>
        IllegalContext = unchecked((int)0xC00E005B),
        /// <internalonly/>
        IllegalSortPropertyId = unchecked((int)0xC00E005C),
        /// <internalonly/>
        LabelBufferTooSmall = unchecked((int)0xC00E005E),
        /// <devdoc>
        ///     The list of MQIS servers (in registry) is empty.
        /// </devdoc>
        MqisServerEmpty = unchecked((int)0xC00E005F),
        /// <devdoc>
        ///     MQIS database is in read-only mode.
        /// </devdoc>
        MqisReadOnlyMode = unchecked((int)0xC00E0060),
        /// <internalonly/>
        SymmetricKeyBufferTooSmall = unchecked((int)0xC00E0061),
        /// <internalonly/>
        SignatureBufferTooSmall = unchecked((int)0xC00E0062),
        /// <internalonly/>
        ProviderNameBufferTooSmall = unchecked((int)0xC00E0063),
        /// <devdoc>
        ///     The operation is illegal on foreign message queuing system.
        /// </devdoc>
        IllegalOperation = unchecked((int)0xC00E0064),
        /// <devdoc>
        ///     Another MQIS server is being installed, write operations to the
        ///     database are not allowed at this stage.
        /// </devdoc>
        WriteNotAllowed = unchecked((int)0xC00E0065),
        /// <devdoc>
        ///     MSMQ independent clients cannot serve MSMQ dependent clients.
        /// </devdoc>
        WksCantServeClient = unchecked((int)0xC00E0066),
        /// <devdoc>
        ///     The number of dependent clients served by this MSMQ server reached
        ///     its upper limit.
        /// </devdoc>
        DependentClientLicenseOverflow = unchecked((int)0xC00E0067),
        /// <devdoc>
        ///     Ini file for queue in LQS was deleted because it was corrupted.
        /// </devdoc>
        CorruptedQueueWasDeleted = unchecked((int)0xC00E0068),
        /// <devdoc>
        ///     The remote machine is not available.
        /// </devdoc>
        RemoteMachineNotAvailable = unchecked((int)0xC00E0069),
        /// <devdoc>
        ///  The operation is not supported for a WORKGROUP installation computer.
        /// </devdoc>
        UnsupportedOperation = unchecked((int)0xC00E006A),
        /// <devdoc>
        ///  The Cryptographic Service Provider  is not supported by Message Queuing.
        /// </devdoc>
        EncryptionProviderNotSupported = unchecked((int)0xC00E006B),
        /// <devdoc>
        ///  Unable to set the security descriptor for the cryptographic keys.
        /// </devdoc>
        CannotSetCryptographicSecurityDescriptor = unchecked((int)0xC00E006C),
        /// <devdoc>
        ///  A user attempted  to send an authenticated message without a certificate.
        /// </devdoc>
        CertificateNotProvided = unchecked((int)0xC00E006D),
        /// <internalonly/>
        QDnsPropertyNotSupported = unchecked((int)0xC00E006E),
        /// <devdoc>
        ///  Unable to create a certificate store for the internal certificate.
        /// </devdoc>
        CannotCreateCertificateStore = unchecked((int)0xC00E006F),
        /// <devdoc>
        ///  Unable to  open the certificates store for the internal certificate.
        /// </devdoc>
        CannotOpenCertificateStore = unchecked((int)0xC00E0070),
        /// <devdoc>
        ///  The operation is invalid for a msmqServices object.
        /// </devdoc>
        IllegalEnterpriseOperation = unchecked((int)0xC00E0071),
        /// <devdoc>
        ///  Failed to grant the "Add Guid" permission to current user.
        /// </devdoc>
        CannotGrantAddGuid = unchecked((int)0xC00E0072),
        /// <devdoc>
        ///  Can't load the MSMQOCM.DLL library.
        /// </devdoc>
        CannotLoadMsmqOcm = unchecked((int)0xC00E0073),
        /// <devdoc>
        ///  Cannot locate an entry point in the MSMQOCM.DLL library.
        /// </devdoc>
        NoEntryPointMsmqOcm = unchecked((int)0xC00E0074),
        /// <devdoc>
        ///  Failed to find Message Queuing servers on domain controllers.
        /// </devdoc>
        NoMsmqServersOnDc = unchecked((int)0xC00E0075),
        /// <devdoc>
        ///  Failed to join MSMQ enterprise on Windows 2000 domain.
        /// </devdoc>
        CannotJoinDomain = unchecked((int)0xC00E0076),
        /// <devdoc>
        ///  Failed to create an object on a specified Global Catalog server.
        /// </devdoc>
        CannotCreateOnGlobalCatalog = unchecked((int)0xC00E0077),
        /// <devdoc>
        ///  Failed to create msmqConfiguration object with GUID that match machine installation. You must uninstall MSMQ and then reinstall it.
        /// </devdoc>
        GuidNotMatching = unchecked((int)0xC00E0078),
        /// <devdoc>
        ///  Unable to find the public key for computer.
        /// </devdoc>
        PublicKeyNotFound = unchecked((int)0xC00E0079),
        /// <devdoc>
        ///  The public key for the computer does not exist.
        /// </devdoc>
        PublicKeyDoesNotExist = unchecked((int)0xC00E007A),
        /// <internalonly/>
        IllegalPrivateProperties = unchecked((int)0xC00E007B),
        /// <devdoc>
        ///  Unable to find Global Catalog servers in the specified domain.
        /// </devdoc>
        NoGlobalCatalogInDomain = unchecked((int)0xC00E007C),
        /// <devdoc>
        ///  Failed to find Message Queuing servers on Global Catalog domain controllers.
        /// </devdoc>
        NoMsmqServersOnGlobalCatalog = unchecked((int)0xC00E007D),
        /// <devdoc>
        ///  Failed to retrieve the distinguished name of local computer.
        /// </devdoc>
        CannotGetDistinguishedName = unchecked((int)0xC00E007E),
        /// <devdoc>
        ///  Unable to hash data for an authenticated message.
        /// </devdoc>
        CannotHashDataEx = unchecked((int)0xC00E007F),
        /// <devdoc>
        ///  Unable to sign data before sending an authenticated message.
        /// </devdoc>
        CannotSignDataEx = unchecked((int)0xC00E0080),
        /// <devdoc>
        ///  Unable to create hash object for an authenticated message.
        /// </devdoc>
        CannotCreateHashEx = unchecked((int)0xC00E0081),
        /// <devdoc>
        ///  Signature of recieved message is not valid.
        /// </devdoc>
        FailVerifySignatureEx = unchecked((int)0xC00E0082),
        /// <devdoc>
        ///  The message referenced by the lookup identifier does not exist.
        /// </devdoc>
        MessageNotFound = unchecked((int)0xC00E0088),
    }
}
