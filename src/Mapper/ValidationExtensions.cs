using System.Collections.Generic;
using System.ComponentModel;

namespace Mapper
{
    public static class ValidationExtensions
    {
        public static void ValidateMapping<TSource, TTarget>(this BaseMap<TSource, TTarget> map)
        {
            var unmappedProperties = new List<PropertyDescriptor>();

            var properties = TypeDescriptor.GetProperties(typeof(TTarget));

            foreach (PropertyDescriptor property in properties)
            {
                
            }
        }
    }
}