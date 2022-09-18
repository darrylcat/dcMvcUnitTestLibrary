using System;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestHelperLibrary.ViewTools
{
    public class MvcToolkit
    {
        public static bool IsViewRecord(object actual)
        {
            return (actual is ViewResult);
        }
    }
}
