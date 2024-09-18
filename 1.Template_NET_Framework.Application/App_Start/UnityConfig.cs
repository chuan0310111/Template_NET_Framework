using _0.Template_NET_Framework.Common.Implement; 
using _0.Template_NET_Framework.Common.Interface;
using _1.Template_NET_Framework.Application.WebApi.Infrastructure.AutoMapper;
using _2.Template_NET_Framework.Services.Implement;
using _2.Template_NET_Framework.Services.Infrastructure.AutoMapper;
using _2.Template_NET_Framework.Services.Interface;
using _3.Template_NET_Framework.Repositories.Implement;
using _3.Template_NET_Framework.Repositories.Interface;
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

            // ContainerControlledLifetimeManager > singleton pattern 單例模式
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

                    mce.AddProfile(typeof(ControllerMapperProfiler));
                    mce.AddProfile(typeof(ServiceMapperProfiler));

                    var mc = new MapperConfiguration(mce);
                    return new Mapper(mc);
                }, new SingletonLifetimeManager()
                );

            container.RegisterType<ISampleService, SampleService>();

            container.RegisterType<IHttpContextBaseCommon, HttpContextBaseCommon>();

            container.RegisterFactory<HttpClient>("HsinChuHttpClient", _ =>
            {
                var baseUri = new Uri(WebConfigurationManager.AppSettings["hsinchuGovUrl"]);

                //設定1分鐘沒有活動即關閉連線，預設-1(永不關閉)
                ServicePointManager.FindServicePoint(baseUri).ConnectionLeaseTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;

                //設定1分鐘更新DNS，預設12000(2分鐘)
                ServicePointManager.DnsRefreshTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;

                var handler = new HttpClientHandler
                {

                };

                var httpClient = HttpClientFactory.Create(handler);
                httpClient.BaseAddress = baseUri;
                return httpClient;
            }, new SingletonLifetimeManager());

            container.RegisterType<IHsinChuRepository, HsinChuRepository>(
                new InjectionConstructor(
                    new ResolvedParameter<ILogger>(),
                    new ResolvedParameter<HttpClient>("HsinChuHttpClient")
                    ));

        }
    }
}