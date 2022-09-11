using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace UnitTestHelperLibrary.Reflection
{
    public class FunctionDefinitionService
    {
        public static MethodInfo MethodOf(Expression<Action> expression)
        {
            var body = (MethodCallExpression)expression.Body;
            return body.Method;
        }

        public static bool MethodHasAttribute(Expression<Action> expression, Type attributeType)
        {
            var method = MethodOf(expression);
            const bool includeInherited = false;
            return method.GetCustomAttributes(attributeType, includeInherited).Any();
        }

        public static bool MethodHasAttribute<TAttribute>(Expression<Action> expression) where TAttribute : Attribute
        {
            var method = MethodOf(expression);
            const bool includeInherited = false;
            return method.GetCustomAttributes(typeof(TAttribute), includeInherited).Any();
        }

        public static bool MethodHasAttributes<T>(string methodName, ICollection<string> expectedAttributes)
        {
            var method = typeof(T).GetMethods().FirstOrDefault(f => f.Name == methodName);
            if(method != null)
            {
                var actualAttributes = method.GetCustomAttributes().Select(s => s.GetType().Name).ToList<string>();
                return AttributesDefinitionService.CheckAttributesExist(expectedAttributes, actualAttributes);
            }
            return false;
        }
    }
}
