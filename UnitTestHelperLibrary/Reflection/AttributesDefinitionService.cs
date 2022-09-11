using System;
using System.Collections.Generic;

namespace UnitTestHelperLibrary.Reflection
{
    public class AttributesDefinitionService
    {

        public static bool CheckAttributesExist(ICollection<string> expectedAttributes, ICollection<string> actualAttributes)
        {
            foreach (var expected in expectedAttributes)
            {
                if (!actualAttributes.Contains(expected)) return false;
            }
            return true;
        }
    }
}
