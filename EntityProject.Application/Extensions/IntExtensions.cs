using EntityProject.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Application.Extensions;

public static class IntExtensions
{
    public static void IsUserIdValidate(this int userId, string paraName)
    {
        if (userId <= 0)
            throw new AppException($"Invalid {paraName}!");
    }
}
