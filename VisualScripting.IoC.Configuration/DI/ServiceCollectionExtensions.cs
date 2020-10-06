﻿using AutoMapper;
using VisualScripting.Services;
using VisualScripting.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VisualScripting.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                services.AddTransient<IUserService, UserService>();
            }
        }

        public static void ConfigureMappings(this IServiceCollection services)
        {
            if (services != null)
            {
                //Automap settings
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
            }
        }
    }
}
