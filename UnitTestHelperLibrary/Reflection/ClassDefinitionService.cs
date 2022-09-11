using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTestHelperLibrary.Reflection
{
    public class ClassDefinitionService
    {

        public static bool HasAttributes<T>(ICollection<string> expectedAttributes)
        {
            var actualAttributes = typeof(T).GetCustomAttributes().Select(s => s.GetType().Name).ToList<string>();
            return AttributesDefinitionService.CheckAttributesExist(expectedAttributes, actualAttributes);
        }

    }
}
