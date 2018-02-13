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
