//------------------------------------------------------------------------------
// <copyright file="MessageQueueCriteria.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Particular.Msmq
{
    using System;
    using System.ComponentModel;
    using System.Globalization; //for CultureInfo
    using Particular.Msmq.Interop;

    /// <devdoc>
    ///    <para>
    ///       This class
    ///       is used to filter MessageQueues when performing a
    ///       query in the network, through MessageQueue.GetPublicQueues method.
    ///    </para>
    /// </devdoc>
    class MessageQueueCriteria
    {
        DateTime createdAfter;
        DateTime createdBefore;
        string label;
        string machine;
        DateTime modifiedAfter;
        DateTime modifiedBefore;
        Guid category;
        readonly CriteriaPropertyFilter filter = new();
        Restrictions restrictions;
        static readonly DateTime minDate = new(1970, 1, 1);
        static readonly DateTime maxDate = new(2038, 1, 19);

        /// <devdoc>
        ///    Specifies the lower bound of the interval
        ///    that will be used as  the queue creation time
        ///    search criteria.
        /// </devdoc>
        public DateTime CreatedAfter
        {
            get
            {
                if (!filter.CreatedAfter)
                {
                    throw new InvalidOperationException(Res.GetString(Res.CriteriaNotDefined));
                }

                return createdAfter;
            }

            set
            {
                if (value < minDate || value > maxDate)
                {
                    throw new ArgumentException(Res.GetString(Res.InvalidDateValue, minDate.ToString(CultureInfo.CurrentCulture), maxDate.ToString(CultureInfo.CurrentCulture)));
                }

                createdAfter = value;
                if (filter.CreatedBefore && createdAfter > createdBefore)
                {
                    createdBefore = createdAfter;
                }

                filter.CreatedAfter = true;
            }
        }

        /// <devdoc>
        ///    Specifies the upper bound of the interval
        ///    that will be used as  the queue creation time
        ///    search criteria.
        /// </devdoc>
        public DateTime CreatedBefore
        {
            get
            {
                if (!filter.CreatedBefore)
                {
                    throw new InvalidOperationException(Res.GetString(Res.CriteriaNotDefined));
                }

                return createdBefore;
            }

            set
            {
                if (value < minDate || value > maxDate)
                {
                    throw new ArgumentException(Res.GetString(Res.InvalidDateValue, minDate.ToString(CultureInfo.CurrentCulture), maxDate.ToString(CultureInfo.CurrentCulture)));
                }

                createdBefore = value;
                if (filter.CreatedAfter && createdAfter > createdBefore)
                {
                    createdAfter = createdBefore;
                }

                filter.CreatedBefore = true;
            }
        }

        internal bool FilterMachine => filter.MachineName;

        /// <devdoc>
        ///    Specifies the label that that will be used as
        ///    the criteria to search queues in the network.
        /// </devdoc>
        public string Label
        {
            get
            {
                if (!filter.Label)
                {
                    throw new InvalidOperationException(Res.GetString(Res.CriteriaNotDefined));
                }

                return label;
            }

            set
            {
                ArgumentNullException.ThrowIfNull(value);

                label = value;
                filter.Label = true;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Specifies the machine name that will be used
        ///       as the criteria to search queues in the network.
        ///    </para>
        /// </devdoc>
        public string MachineName
        {
            get
            {
                if (!filter.MachineName)
                {
                    throw new InvalidOperationException(Res.GetString(Res.CriteriaNotDefined));
                }

                return machine;
            }

            set
            {
                if (!SyntaxCheck.CheckMachineName(value))
                {
                    throw new ArgumentException(Res.GetString(Res.InvalidProperty, "MachineName", value));
                }

                machine = value;
                filter.MachineName = true;
            }
        }

        /// <devdoc>
        ///    Specifies the lower bound of the interval
        ///    that will be used as  the queue modified time
        ///    search criteria.
        /// </devdoc>
        public DateTime ModifiedAfter
        {
            get
            {
                if (!filter.ModifiedAfter)
                {
                    throw new InvalidOperationException(Res.GetString(Res.CriteriaNotDefined));
                }

                return modifiedAfter;
            }

            set
            {
                if (value < minDate || value > maxDate)
                {
                    throw new ArgumentException(Res.GetString(Res.InvalidDateValue, minDate.ToString(CultureInfo.CurrentCulture), maxDate.ToString(CultureInfo.CurrentCulture)));
                }

                modifiedAfter = value;

                if (filter.ModifiedBefore && modifiedAfter > modifiedBefore)
                {
                    modifiedBefore = modifiedAfter;
                }

                filter.ModifiedAfter = true;
            }
        }

        /// <devdoc>
        ///    Specifies the upper bound of the interval
        ///    that will be used as  the queue modified time
        ///    search criteria.
        /// </devdoc>
        public DateTime ModifiedBefore
        {
            get
            {
                if (!filter.ModifiedBefore)
                {
                    throw new InvalidOperationException(Res.GetString(Res.CriteriaNotDefined));
                }

                return modifiedBefore;
            }

            set
            {
                if (value < minDate || value > maxDate)
                {
                    throw new ArgumentException(Res.GetString(Res.InvalidDateValue, minDate.ToString(CultureInfo.CurrentCulture), maxDate.ToString(CultureInfo.CurrentCulture)));
                }

                modifiedBefore = value;

                if (filter.ModifiedAfter && modifiedAfter > modifiedBefore)
                {
                    modifiedAfter = modifiedBefore;
                }

                filter.ModifiedBefore = true;
            }
        }

        /// <internalonly/>
        internal Restrictions.MQRESTRICTION Reference
        {
            get
            {
                int size = 0;
                if (filter.CreatedAfter)
                {
                    ++size;
                }

                if (filter.CreatedBefore)
                {
                    ++size;
                }

                if (filter.Label)
                {
                    ++size;
                }

                if (filter.ModifiedAfter)
                {
                    ++size;
                }

                if (filter.ModifiedBefore)
                {
                    ++size;
                }

                if (filter.Category)
                {
                    ++size;
                }

                restrictions = new Restrictions(size);
                if (filter.CreatedAfter)
                {
                    restrictions.AddI4(NativeMethods.QUEUE_PROPID_CREATE_TIME, Restrictions.PRGT, ConvertTime(createdAfter));
                }

                if (filter.CreatedBefore)
                {
                    restrictions.AddI4(NativeMethods.QUEUE_PROPID_CREATE_TIME, Restrictions.PRLE, ConvertTime(createdBefore));
                }

                if (filter.Label)
                {
                    restrictions.AddString(NativeMethods.QUEUE_PROPID_LABEL, Restrictions.PREQ, label);
                }

                if (filter.ModifiedAfter)
                {
                    restrictions.AddI4(NativeMethods.QUEUE_PROPID_MODIFY_TIME, Restrictions.PRGT, ConvertTime(modifiedAfter));
                }

                if (filter.ModifiedBefore)
                {
                    restrictions.AddI4(NativeMethods.QUEUE_PROPID_MODIFY_TIME, Restrictions.PRLE, ConvertTime(modifiedBefore));
                }

                if (filter.Category)
                {
                    restrictions.AddGuid(NativeMethods.QUEUE_PROPID_TYPE, Restrictions.PREQ, category);
                }

                return restrictions.GetRestrictionsRef();
            }
        }

        /// <devdoc>
        ///    Specifies the Category that will be used
        ///    as the criteria to search queues in the network.
        /// </devdoc>
        public Guid Category
        {
            get
            {
                if (!filter.Category)
                {
                    throw new InvalidOperationException(Res.GetString(Res.CriteriaNotDefined));
                }

                return category;
            }

            set
            {
                category = value;
                filter.Category = true;
            }
        }

        /// <devdoc>
        ///    Resets all the current instance settings.
        /// </devdoc>
        public void ClearAll()
        {
            filter.ClearAll();
        }

        /// <internalonly/>
        static int ConvertTime(DateTime time)
        {
            time = time.ToUniversalTime();
            return (int)(time - minDate).TotalSeconds;
        }

        /// <internalonly/>
        class CriteriaPropertyFilter
        {
            public bool CreatedAfter;
            public bool CreatedBefore;
            public bool Label;
            public bool MachineName;
            public bool ModifiedAfter;
            public bool ModifiedBefore;
            public bool Category;

            public void ClearAll()
            {
                CreatedAfter = false;
                CreatedBefore = false;
                Label = false;
                MachineName = false;
                ModifiedAfter = false;
                ModifiedBefore = false;
                Category = false;
            }
        }
    }
}
