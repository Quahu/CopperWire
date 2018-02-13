using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopperWire.Plugins
{
    /// <summary>
    /// Represents a base plugin for <see cref="ClientBase"/>.
    /// </summary>
    public abstract class PluginBase
    {
        /// <summary>
        /// <para>Executed when the plugin is installed on a client instance.</para>
        /// <para>This method should initialize the plugin for supplied client instance.</para>
        /// </summary>
        /// <param name="client">Client instance on which the plugin is being installed.</param>
        protected internal abstract void OnInstalling(ClientBase client);

        /// <summary>
        /// <para>Executed when the plugin is being removed from a client instance.</para>
        /// <para>This method should deinitialize the plugin for supplied client instance.</para>
        /// </summary>
        /// <param name="client">Client instance from which the plugin is being removed.</param>
        protected internal abstract void OnRemoving(ClientBase client);
    }
}
