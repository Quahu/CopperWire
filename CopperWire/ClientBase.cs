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
using CopperWire.Logging;
using CopperWire.Plugins;

namespace CopperWire
{
    /// <summary>
    /// <para>Base for all types of clients for Discord API. It provides certain properties common to all Discord API client implementations.</para>
    /// <para>Most other client implementations derive from this class.</para>
    /// </summary>
    public abstract class ClientBase
    {
        /// <summary>
        /// Gets the plugins installed on this client instance.
        /// </summary>
        public IReadOnlyList<PluginBase> Plugins => this._pluginsLazy.Value;
        private List<PluginBase> _plugins;
        private Lazy<IReadOnlyList<PluginBase>> _pluginsLazy;

        /// <summary>
        /// Gets the logger instance for this client.
        /// </summary>
        public Logger Logger { get; }

        /// <summary>
        /// Initializes this client instance.
        /// </summary>
        protected ClientBase()
        {
#warning TODO: Config

            // initialize the plugin container
            this._plugins = new List<PluginBase>();
            this._pluginsLazy = new Lazy<IReadOnlyList<PluginBase>>(() => new ReadOnlyCollection<PluginBase>(this._plugins));

            // intialize the logger
            this.Logger = new Logger(LogLevel.Trace);
        }

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
            plugin.OnRemoving(this);
            if (plugin != null)
                this._plugins.Remove(plugin);

            // return the instance
            return plugin;
        }
    }
}
