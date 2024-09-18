using _0.Template_NET_Framework.Common.Implement; 
using _0.Template_NET_Framework.Common.Interface;
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace _1.Template_NET_Framework.Application
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            var appSettings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                { "hsinchuGovUrl", WebConfigurationManager.AppSettings["hsinchuGovUrl"]}
            };

            // ContainerControlledLifetimeManager > singleton pattern ³æ¨Ò¼Ò¦¡
            container.RegisterType<IAppSettings, AppSettings>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(appSettings)
                );

            container.RegisterFactory<HttpContextBase>(_ => new HttpContextWrapper(HttpContext.Current));

            container.RegisterType<ILogger, Logger>(new InjectionConstructor(
                new ResolvedParameter<HttpContextBase>(), 
                "channelName01"
                ));

            container.RegisterFactory<IMapper>(
                
                ct => {

                    var mce = new MapperConfigurationExpression();
                    //mce.AddProfile(typeof(#if))

                    var mc = new MapperConfiguration(mce);
                    return new Mapper(mc);
                }, new SingletonLifetimeManager()
                );

            container.RegisterType<IHttpContextBaseCommon, HttpContextBaseCommon>();

        }
    }
}