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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CopperWire
{
    /// <summary>
    /// <para>Discord API client which uses both WebSocket and REST to communicate with Discord.</para>
    /// <para>This implementation is typically used by bots, which require both WebSocket and REST access to Discord API.</para>
    /// </summary>
    public sealed class Client : ClientBase
    {
        #region Properties
        /// <summary>
        /// Gets the ID of the client's current shard.
        /// </summary>
        public int ShardId { get; }

        /// <summary>
        /// Gets the total number of shards for this client.
        /// </summary>
        public int ShardCount { get; }

        /// <summary>
        /// Gets the appropriately-typed settings for this client.
        /// </summary>
        private new ClientSettings Settings => base.Settings as ClientSettings;
        #endregion

        /// <summary>
        /// Initializes this client instance.
        /// </summary>
        /// <param name="services">Services to use for initializing this client.</param>
        /// <param name="shardId">Id of the shard to connect to. Defaults to <c>0</c>.</param>
        /// <param name="shardCount">Total number of shards to use when connecting. Defaults to <c>1</c>.</param>
        public Client(IServiceProvider services, int shardId = 0, int shardCount = 1)
            : base(services, new EventId(shardId, "CopperWire"))
        {
            // check if valid shard data passed
            if (shardId >= shardCount)
                throw new ArgumentOutOfRangeException(nameof(shardId), "Shard ID needs to be lower than total shard count.");

            if (shardId < 0)
                throw new ArgumentOutOfRangeException(nameof(shardId), "Shard ID cannot be negative.");

            if (shardCount < 1)
                throw new ArgumentOutOfRangeException(nameof(shardCount), "Shard count must be greater than zero.");

            // assign shard data
            this.ShardId = shardId;
            this.ShardCount = shardCount;

            // get the configuration
            var cfg = services.GetRequiredService<IOptions<ClientSettings>>();
            base.Settings = cfg.Value;

            // trace this
            this.Logger?.LogTrace(this.EventId, "Client initialized; shard={0} count={1}", this.ShardId, this.ShardCount);
        }
    }
}
