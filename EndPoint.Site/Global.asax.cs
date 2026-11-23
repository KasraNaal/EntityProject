using Autofac;
using Autofac.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
using EntityProject.Persistence.Context;
using EntityProject.Persistence.DataAccess;

namespace EndPoint.Site
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        public static IContainerProvider containerProvider;
        public IContainerProvider ContainerProvider 
        { 
            get
            {
                return containerProvider;
            } 
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataBaseContext>().As<IDb>().InstancePerLifetimeScope();
            builder.RegisterType<UserRegisterService>().As<IUserRegisterService>().InstancePerLifetimeScope();
            builder.RegisterType<UserValidation>().As<IUserValidation>().InstancePerLifetimeScope();
            builder.RegisterType<UserDataAccess>().As<IUserDataAccess>().InstancePerLifetimeScope();
            builder.RegisterType<SearchUsers>().As<ISearchUsers>().InstancePerLifetimeScope();
            builder.RegisterType<GetUserById>().As<IGetUserById>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateUser>().As<IUpdateUser>().InstancePerLifetimeScope();
            builder.RegisterType<SearchPerson>().As<ISearchPerson>().InstancePerLifetimeScope();
            builder.RegisterType<Delete>().As<IDeleteUser>().InstancePerLifetimeScope();
            builder.RegisterType<UserExist>().As<IIsUserExist>().InstancePerLifetimeScope();
            builder.RegisterType<PersonDataAccess>().As<IPersonDataAccess>().InstancePerLifetimeScope();

            var container = builder.Build();

            containerProvider = new ContainerProvider(container);
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
            //Container?.Dispose();
        }
    }
}