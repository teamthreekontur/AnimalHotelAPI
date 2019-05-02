﻿using Models.Place.Repository;
using Models.User.Repository;
using MongoDB.Driver;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Xml.XPath;
using Unity;
using Unity.Lifetime;

namespace AnimalHotelApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var mongoClient = new MongoClient(ConfigurationManager.ConnectionStrings["AniHoDb"].ConnectionString);
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, DbUserRepository>();
            container.RegisterType<IPlaceRepository, DbPlaceRepository>();
            container.RegisterInstance<IMongoClient>(mongoClient);

            config.DependencyResolver = new UnityResolver(container);

            // Attribute routing
            config.MapHttpAttributeRoutes();

            // Redirect root to Swagger UI
            config.Routes.MapHttpRoute(
                name: "Swagger UI",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
