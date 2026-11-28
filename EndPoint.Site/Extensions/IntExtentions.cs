using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndPoint.Site.Extensions
{
    public static class IntExtentions
    {
        public static int GetIntFromQueryString(this HttpRequest request, string key)
        {
            int.TryParse(request.QueryString[key], out int result);
            return result;
        }
    }
}