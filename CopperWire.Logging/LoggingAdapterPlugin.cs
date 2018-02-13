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
using System.Text;
using CopperWire.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using cwl = CopperWire.Logging;

namespace CopperWire
{
    /// <summary>
    /// <para>A <see cref="ILogger"/> logging adapter plugin for CopperWire.</para>
    /// <para>This plugin provides a bridge between CopperWire's own logger implementation, and Microsoft's logging abstractions, which enable usage of various other logging implementations.</para>
    /// </summary>
    public class LoggingAdapterPlugin : PluginBase
    {
        /// <summary>
        /// Gets the logger instance for this adapter.
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Creates a new <see cref="LoggingAdapterPlugin"/> plugin for CopperWire.
        /// </summary>
        /// <param name="logger">Logger instance to use with this adapter.</param>
        public LoggingAdapterPlugin(ILogger logger)
        {
            this.Logger = logger;
        }

        /// <summary>
        /// Initializes the logging bridge for specified client instance.
        /// </summary>
        /// <param name="client">Client instance to intialize the plugin for.</param>
        protected override void OnInstalling(ClientBase client)
        {
            client.Logger.EventLogged += this.Logger_EventLogged;
        }

        /// <summary>
        /// Deinitializes the logging bridge for specified client instance.
        /// </summary>
        /// <param name="client">Client instance to deinitialize the plugin for.</param>
        protected override void OnRemoving(ClientBase client)
        {
            throw new NotImplementedException();
        }

        private void Logger_EventLogged(object sender, cwl.LogEventArgs e)
        {
            this.Logger.Log((LogLevel)e.LogLevel, new EventId(0, e.Tag), e.Message, e.Exception, FormatEvent);

            string FormatEvent(string message, Exception ex)
                => $"{message}{Environment.NewLine}{ex}";
        }
    }
}
