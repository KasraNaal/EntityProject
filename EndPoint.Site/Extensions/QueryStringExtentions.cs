using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;

namespace EndPoint.Site.Extensions
{
    public static class QueryStringExtentions
    {
        public static int GetId(this NameValueCollection request)
        {
            if (!int.TryParse(request["id"], out int result))
                throw new InvalidDataException("Invalid User id!");

            return result;
        }
    }
}