﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetEscapades.Configuration.Remote
{

    /// <summary>
    /// Extension methods for adding <see cref="RemoteConfigurationProvider"/>.
    /// </summary>
    public static class RemoteConfigurationExtensions
    {
        /// <summary>
        /// Adds a remote configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="configurationUri">The remote uri to </param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddRemoteSource(this IConfigurationBuilder builder, Uri configurationUri)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configurationUri == null)
            {
                throw new ArgumentNullException(nameof(configurationUri));
            }

            var source = new RemoteConfigurationSource
            {
                ConfigurationUri = configurationUri,
            };

            return builder.AddRemoteSource(source);
        }

        /// <summary>
        /// Adds a remote configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="configurationUri">The remote uri to </param>
        /// <param name="events">Events that get add </param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddRemoteSource(this IConfigurationBuilder builder, Uri configurationUri, RemoteConfigurationEvents events)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configurationUri == null)
            {
                throw new ArgumentNullException(nameof(configurationUri));
            }

            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            var source = new RemoteConfigurationSource
            {
                ConfigurationUri = configurationUri,
                Events = events,
            };

            return builder.AddRemoteSource(source);
        }

        public static IConfigurationBuilder AddRemoteSource(this IConfigurationBuilder builder, RemoteConfigurationSource source)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            builder.Add(source);
            return builder;
        }
    }
}