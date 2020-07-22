using Autofac;
using Autofac.Integration.Mvc;
using LiMarket_V1._0._0.Controllers;
using LiMarket_V1._0._0.Models;
using LiMarket_V1._0._0.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiMarket_V1._0._0.Tools
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(AdminController).Assembly);

            // регистрируем споставление типов
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>))
                .WithProperty("Context", new MsContext());

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}