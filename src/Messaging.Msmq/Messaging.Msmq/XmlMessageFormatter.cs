//------------------------------------------------------------------------------
// <copyright file="XmlMessageFormatter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Messaging.Msmq
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter"]/*' />
    /// <devdoc>
    ///    Formatter class that serializes and deserializes objects into
    ///    and from  MessageQueue messages using Xml.
    /// </devdoc>
    public class XmlMessageFormatter : IMessageFormatter
    {
        private Type[] targetTypes;
        private string[] targetTypeNames;
        readonly Hashtable targetSerializerTable = new();
        private bool typeNamesAdded;
        private bool typesAdded;

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.XmlMessageFormatter"]/*' />
        /// <devdoc>
        ///    Creates a new Xml message formatter object.
        /// </devdoc>
        public XmlMessageFormatter()
        {
            this.TargetTypes = Array.Empty<Type>();
            this.TargetTypeNames = Array.Empty<string>();
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.XmlMessageFormatter1"]/*' />
        /// <devdoc>
        ///    Creates a new Xml message formatter object,
        ///    using the given properties.
        /// </devdoc>
        public XmlMessageFormatter(string[] targetTypeNames)
        {
            this.TargetTypeNames = targetTypeNames;
            this.TargetTypes = Array.Empty<Type>();
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.XmlMessageFormatter2"]/*' />
        /// <devdoc>
        ///    Creates a new Xml message formatter object,
        ///    using the given properties.
        /// </devdoc>
        public XmlMessageFormatter(Type[] targetTypes)
        {
            this.TargetTypes = targetTypes;
            this.TargetTypeNames = Array.Empty<string>();
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.TargetTypeNames"]/*' />
        /// <devdoc>
        ///    Specifies the set of possible types that will
        ///    be deserialized by the formatter from the
        ///    message provided.
        /// </devdoc>
        public string[] TargetTypeNames
        {
            get
            {
                return this.targetTypeNames;
            }

            set
            {
                ArgumentNullException.ThrowIfNull(value);

                this.typeNamesAdded = false;
                this.targetTypeNames = value;
            }
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.TargetTypes"]/*' />
        /// <devdoc>
        ///    Specifies the set of possible types that will
        ///    be deserialized by the formatter from the
        ///    message provided.
        /// </devdoc>
        public Type[] TargetTypes
        {
            get
            {
                return this.targetTypes;
            }

            set
            {
                ArgumentNullException.ThrowIfNull(value);

                this.typesAdded = false;
                this.targetTypes = value;
            }
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.CanRead"]/*' />
        /// <devdoc>
        ///    When this method is called, the formatter will attempt to determine
        ///    if the contents of the message are something the formatter can deal with.
        /// </devdoc>
        public bool CanRead(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);

            this.CreateTargetSerializerTable();

            Stream stream = message.BodyStream;
            XmlTextReader reader = new(stream);
            reader.WhitespaceHandling = WhitespaceHandling.Significant;
            reader.DtdProcessing = DtdProcessing.Prohibit;
            bool result = false;
            foreach (XmlSerializer serializer in targetSerializerTable.Values)
            {
                if (serializer.CanDeserialize(reader))
                {
                    result = true;
                    break;
                }
            }

            message.BodyStream.Position = 0; // reset stream in case CanRead is followed by Deserialize
            return result;
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.Clone"]/*' />
        /// <devdoc>
        ///    This method is needed to improve scalability on Receive and ReceiveAsync scenarios.  Not requiring
        ///     thread safety on read and write.
        /// </devdoc>
        public object Clone()
        {
            XmlMessageFormatter formatter = new();
            formatter.targetTypes = targetTypes;
            formatter.targetTypeNames = targetTypeNames;
            formatter.typesAdded = typesAdded;
            formatter.typeNamesAdded = typeNamesAdded;
            foreach (Type targetType in targetSerializerTable.Keys)
                formatter.targetSerializerTable[targetType] = new XmlSerializer(targetType);

            return formatter;
        }

        /// <internalonly/>
        private void CreateTargetSerializerTable()
        {
            if (!this.typeNamesAdded)
            {
                for (int index = 0; index < this.targetTypeNames.Length; ++index)
                {
                    Type targetType = Type.GetType(this.targetTypeNames[index], true);
                    if (targetType != null)
                        this.targetSerializerTable[targetType] = new XmlSerializer(targetType);
                }

                this.typeNamesAdded = true;
            }

            if (!this.typesAdded)
            {
                for (int index = 0; index < this.targetTypes.Length; ++index)
                    this.targetSerializerTable[this.targetTypes[index]] = new XmlSerializer(this.targetTypes[index]);

                this.typesAdded = true;
            }

            if (this.targetSerializerTable.Count == 0)
                throw new InvalidOperationException(Res.GetString(Res.TypeListMissing));
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.Read"]/*' />
        /// <devdoc>
        ///    This method is used to read the contents from the given message
        ///     and create an object.
        /// </devdoc>
        public object Read(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);

            this.CreateTargetSerializerTable();

            Stream stream = message.BodyStream;
            XmlTextReader reader = new(stream);
            reader.WhitespaceHandling = WhitespaceHandling.Significant;
            reader.DtdProcessing = DtdProcessing.Prohibit;
            foreach (XmlSerializer serializer in targetSerializerTable.Values)
            {
                if (serializer.CanDeserialize(reader))
                    return serializer.Deserialize(reader);
            }

            throw new InvalidOperationException(Res.GetString(Res.InvalidTypeDeserialization));
        }

        /// <include file='doc\XmlMessageFormatter.uex' path='docs/doc[@for="XmlMessageFormatter.Write"]/*' />
        /// <devdoc>
        ///    This method is used to write the given object into the given message.
        ///     If the formatter cannot understand the given object, an exception is thrown.
        /// </devdoc>
        public void Write(Message message, object obj)
        {
            ArgumentNullException.ThrowIfNull(message);

            ArgumentNullException.ThrowIfNull(obj);

            Stream stream = new MemoryStream();
            Type serializedType = obj.GetType();
            XmlSerializer serializer = null;
            if (this.targetSerializerTable.ContainsKey(serializedType))
                serializer = (XmlSerializer)this.targetSerializerTable[serializedType];
            else
            {
                serializer = new XmlSerializer(serializedType);
                this.targetSerializerTable[serializedType] = serializer;
            }

            serializer.Serialize(stream, obj);
            message.BodyStream = stream;
            //Need to reset the body type, in case the same message
            //is reused by some other formatter.
            message.BodyType = 0;
        }
    }
}
