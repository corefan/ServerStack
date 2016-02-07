﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ServerStack
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseStartup<TStartup>(this IHostBuilder builder)
        {
            return builder.UseStartup(typeof(TStartup));
        }
    }

    public interface IHostBuilder
    {
        /// <summary>
        /// Builds an <see cref="IHost"/> which hosts a web application.
        /// </summary>
        IHost Build();

        /// <summary>
        /// Specify the <see cref="IServerFactory"/> to be used by the web host.
        /// </summary>
        /// <param name="factory">The <see cref="IServerFactory"/> to be used.</param>
        /// <returns>The <see cref="IHostBuilder"/>.</returns>
        IHostBuilder UseServer(IServerFactory factory);

        IHostBuilder UseServer<TServerFactory>();

        /// <summary>
        /// Specify the startup type to be used by the web host. 
        /// </summary>
        /// <param name="startupType">The <see cref="Type"/> to be used.</param>
        /// <returns>The <see cref="IHostBuilder"/>.</returns>
        IHostBuilder UseStartup(Type startupType);

        /// <summary>
        /// Specify the delegate that is used to configure the services of the web application.
        /// </summary>
        /// <param name="configureServices">The delegate that configures the <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IHostBuilder"/>.</returns>
        IHostBuilder ConfigureServices(Action<IServiceCollection> configureServices);

        /// <summary>
        /// Specify the startup method to be used to configure the web application. 
        /// </summary>
        /// <param name="configureApplication">The delegate that configures the <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IHostBuilder"/>.</returns>
        IHostBuilder Configure<TContext>(Action<IApplicationBuilder<TContext>> configureApplication);

        /// <summary>
        /// Add or replace a setting in the configuration.
        /// </summary>
        /// <param name="key">The key of the setting to add or replace.</param>
        /// <param name="value">The value of the setting to add or replace.</param>
        /// <returns>The <see cref="IHostBuilder"/>.</returns>
        IHostBuilder UseSetting(string key, string value);

        /// <summary>
        string GetSetting(string key);
    }
}