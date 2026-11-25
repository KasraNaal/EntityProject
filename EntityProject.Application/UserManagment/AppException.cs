using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Application.UserManagment;

public class AppException : Exception
{
    public string UserMessage { get; }

    public AppException(string userMessage): base(userMessage)
    {
        UserMessage = userMessage;
    }

    public AppException(string userMessage, Exception innerException): base(userMessage, innerException)
    {
        UserMessage = userMessage;
    }
}
