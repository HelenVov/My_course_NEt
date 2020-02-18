﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using DataAccess.Models;
using Task1_MVS.WorkWithData;

namespace Task1_MVS.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<WorkWithDatabase>().As<WorkWithDatabase>();
            builder.RegisterType<SetBlogDataContext>().As<SetBlogDataContext>().SingleInstance();
            builder.RegisterType<Сonverter>().As<Сonverter>().SingleInstance();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}