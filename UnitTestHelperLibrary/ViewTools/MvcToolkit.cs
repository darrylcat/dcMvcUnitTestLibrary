using System;
using System.Web.Mvc;

namespace UnitTestHelperLibrary.ViewTools
{
    public class MvcToolkit
    {
        public static bool IsViewRecord(object actual)
        {
            return (actual.GetType().Name.EndsWith("ViewResult"));
        }
    }
}
