using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace Movies.Web.Shared
{
    public static class DateExtensions
    {
        public static string Year(this DateTime? dt)
        {
            return dt?.Year.ToString();
        }
    }
}