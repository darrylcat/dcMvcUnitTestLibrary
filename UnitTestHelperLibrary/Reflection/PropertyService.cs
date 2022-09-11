using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTestHelperLibrary.Reflection
{
    public class PropertyService
    {

        public static bool ObjectPropertiesMatch(object expected, object actual)
        {
            var actualProperties = GetPropertyInfo(actual);
            var expectedProperties = GetPropertyInfo(expected);
            foreach(var expectedProperty in expectedProperties)
            {
                var actualProperty = actualProperties.FirstOrDefault(f => f.Name == expectedProperty.Name);
                if(actualProperty == null)
                {
                    return false;
                }
                string expectedValue = GetPropertyValue(expected, expectedProperty);
                string actualValue = GetPropertyValue(actual, actualProperty);
                if (expectedValue != actualValue) return false;
            }
            return true;
        }

        private static ICollection<PropertyInfo> GetPropertyInfo(object obj)
        {
            var info = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return info;
        }

        private static string GetPropertyValue(object obj, PropertyInfo property)
        {
            if (property.GetValue(obj) == null) return null;
            return property.GetValue(obj).ToString();
        }
    }
}
