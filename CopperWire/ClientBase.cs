// This file is a part of CopperWire project.
// 
// Copyright 2018 Emzi0767
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopperWire.Http;
using CopperWire.Plugins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CopperWire
{
    /// <summary>
    /// <para>Base for all types of clients for Discord API. It provides certain properties common to all Discord API client implementations.</para>
    /// <para>Most other client implementations derive from this class.</para>
    /// </summary>
    public abstract class ClientBase
    {
        #region Properties
        /// <summary>
        /// Gets the service provider used to initialize this client.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Gets the logger instance for this client.
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Gets the API client used to handle REST requests.
        /// </summary>
        public ApiClient ApiClient { get; }

        /// <summary>
        /// Gets the plugins installed on this client instance.
        /// </summary>
        public IReadOnlyList<PluginBase> Plugins => this._pluginsLazy.Value;
        private List<PluginBase> _plugins;
        private Lazy<IReadOnlyList<PluginBase>> _pluginsLazy;

        /// <summary>
        /// Gets the Event ID for events emitted by this client's logger instance.
        /// </summary>
        protected EventId EventId { get; }

        /// <summary>
        /// Gets the configuration settings for this client.
        /// </summary>
        protected ClientBaseSettings Settings { get; set; }
        #endregion

        /// <summary>
        /// Initializes this client instance.
        /// </summary>
        /// <param name="services">Services to use for initializing this client.</param>
        /// <param name="eventId">Event ID for events emitted by this client's logger.</param>
        protected ClientBase(IServiceProvider services, EventId eventId)
        {
            // get the configuration
            var cfg = services.GetRequiredService<IOptions<ClientBaseSettings>>();
            this.Settings = cfg.Value;

            // set up the logger
            this.EventId = eventId;
            this.Logger = services.GetService<ILogger<ClientBase>>();
            this.Logger?.LogTrace(this.EventId, "Logger successfully initialized.");

            // initialize the plugin container
            this._plugins = new List<PluginBase>();
            this._pluginsLazy = new Lazy<IReadOnlyList<PluginBase>>(() => new ReadOnlyCollection<PluginBase>(this._plugins));

            // initialize the api client
            this.ApiClient = services.GetRequiredService<ApiClient>();
        }

        #region Plugin management
        /// <summary>
        /// Installs a plugin into this <see cref="ClientBase"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of the plugin to install.</typeparam>
        /// <param name="plugin">Plugin to install.</param>
        /// <exception cref="ArgumentException">Specified plugin type is already installed on this client instance.</exception>
        public void InstallPlugin<T>(T plugin) 
            where T : PluginBase
        {
            // check if a given plugin type is already installed.
            if (this._plugins.Any(x => x is T))
                throw new ArgumentException("A plugin of specified type was already installed into this client instance.", nameof(T));

            // it's not; let's install it
            this._plugins.Add(plugin);
            plugin.OnInstalling(this);

            this.Logger?.LogInformation(this.EventId, "Installed plugin {0}", typeof(T));
        }

        /// <summary>
        /// Retrieves an instance of a plugin installed into this client instance.
        /// </summary>
        /// <typeparam name="T">Type of the plugin to retrieve.</typeparam>
        /// <returns>Requested plugin instance, or null if specified plugin type was not present on the client.</returns>
        public T GetPlugin<T>()
            where T : PluginBase
            => this._plugins.FirstOrDefault(x => x is T) as T;

        /// <summary>
        /// Removes a previously-installed plugin from this client instance.
        /// </summary>
        /// <typeparam name="T">Type of the plugin to uninstall.</typeparam>
        /// <returns>The uninstalled plugin instance, or null if specified plugin type was not present on the client.</returns>
        public T RemovePlugin<T>()
            where T : PluginBase
        {
            // get the plugin instance
            var plugin = this._plugins.FirstOrDefault(x => x is T) as T;

            // can we uninstall? if so, do it
            if (plugin != null)
            {
                plugin.OnRemoving(this);
                this._plugins.Remove(plugin);

                this.Logger?.LogInformation(this.EventId, "Removed plugin {0}", typeof(T));
            }

            // return the instance
            return plugin;
        }
        #endregion
    }
}
