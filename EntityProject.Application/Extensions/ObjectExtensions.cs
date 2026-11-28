using EntityProject.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Application.Extensions;

public static class ObjectExtensions
{
    public static T IsObjectFound<T>(this T entity, string entityName) where T : class
    {
        if (entity is null)
            throw new AppException($"{entityName} not found!");

        return entity;
    }
}
