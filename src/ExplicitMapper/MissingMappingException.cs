using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mapper
{

    [Serializable]
    public class MissingMappingException : Exception
    {
        public MissingMappingException(IEnumerable<PropertyDescriptor> missingProperties)
            : base(BuildMessage(missingProperties)) { }

        protected MissingMappingException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        private static string BuildMessage(IEnumerable<PropertyDescriptor> missingProperties)
        {
            return null;
        }
    }
}