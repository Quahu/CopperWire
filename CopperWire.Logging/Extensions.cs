using Microsoft.Extensions.Logging;

namespace CopperWire
{
    /// <summary>
    /// Various extension methods for <see cref="ClientBase"/>.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// <para>Enables the use of Microsoft logging abstraction bridge on specified <see cref="ClientBase"/> instance, using specified <see cref="ILogger"/> instance.</para>
        /// <para>This method will create a new logger plugin instance.</para>
        /// </summary>
        /// <param name="client">CopperWire client instance to install the plugin on.</param>
        /// <param name="logger">Logger instance to use for logging. Please note that this should usually have its own scope.</param>
        /// <returns>The client instance.</returns>
        public static ClientBase UseLoggingPlugin(this ClientBase client, ILogger logger)
        {
            var plugin = new LoggingAdapterPlugin(logger);
            client.InstallPlugin(plugin);

            return client;
        }

        /// <summary>
        /// <para>Enables the use of Microsoft logging abstraction bridge on specified <see cref="ClientBase"/> instance, using supplied <see cref="LoggingAdapterPlugin"/> instance.</para>
        /// <para>This method will use the existing logger plugin instance.</para>
        /// </summary>
        /// <param name="client">CopperWire client instance to install the plugin on.</param>
        /// <param name="plugin">Logging plugin instance to install.</param>
        /// <returns>The client instance.</returns>
        public static ClientBase UseLoggingPlugin(this ClientBase client, LoggingAdapterPlugin plugin)
        {
            client.InstallPlugin(plugin);

            return client;
        }

        /// <summary>
        /// Retrieves the installed Microsoft logging abstraction bridge plugin from specified <see cref="ClientBase"/> instance.
        /// </summary>
        /// <param name="client">CopperWire client instance to retrieve the plugin from.</param>
        /// <returns>The plugin instance.</returns>
        public static LoggingAdapterPlugin GetLoggingPlugin(this ClientBase client)
        {
            var plugin = client.GetPlugin<LoggingAdapterPlugin>();

            return plugin;
        }

        /// <summary>
        /// Removes a previously-installed Microsoft logging abstraction bridge plugin from specified <see cref="ClientBase"/> instance.
        /// </summary>
        /// <param name="client">CopperWire client isntance to remove the plugin from.</param>
        /// <returns>The removed plugin instance.</returns>
        public static LoggingAdapterPlugin RemoveLoggingPlugin(this ClientBase client)
        {
            var plugin = client.RemovePlugin<LoggingAdapterPlugin>();

            return plugin;
        }
    }
}
