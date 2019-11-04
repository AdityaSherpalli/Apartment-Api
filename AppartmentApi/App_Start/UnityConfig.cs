using AppartmentApi.Repositories.Implementations;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace AppartmentApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IDbContext, DatabaseContext>();

            container.RegisterType<IApartmentRepository, ApartmentRepository>();
            container.RegisterType<IFlatRepository, FlatRepository>();
            container.RegisterType<IFlatMemberRepository, FlatMemberRepository>();
            container.RegisterType<IPeopleRepository, PeopleRepository>();
            container.RegisterType<IMaintenenceItemRepository, MaintenenceItemRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}