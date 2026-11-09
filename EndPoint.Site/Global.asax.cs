using Autofac;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UseCase;
using EntittyProject.Application.UserManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using EntityProject.Persistence.DataAccess;
using EntityProject.Persistence.Contexts;

namespace EndPoint.Site
{
    public class Global : System.Web.HttpApplication
    {
        public static IContainer Container { get; set; }
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataBaseContext>().As<EntityProject.Application.Interface.IDb>().InstancePerLifetimeScope();
            builder.RegisterType<UserRegisterService>().As<IUserRegisterService>().InstancePerLifetimeScope();
            builder.RegisterType<UserValidation>().As<IUserValidation>().InstancePerLifetimeScope();
            builder.RegisterType<UserDataAccess>().As<IUserDataAccess>().InstancePerLifetimeScope();

            Container = builder.Build();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}