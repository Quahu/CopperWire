﻿// This file is a part of CopperWire project.
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
using CopperWire.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CopperWire
{
    /// <summary>
    /// <para>REST-only Discord API client.</para>
    /// <para>This implementation can be used for scenarios where a complete client implementation is not necessary or available, such as OAuth2 applications.</para>
    /// </summary>
    public class RestClient : ClientBase
    {

        /// <summary>
        /// Initializes this client instance.
        /// </summary>
        /// <param name="services"></param>
        public RestClient(IServiceProvider services)
            : base(services, new EventId(0, "CopperWire"))
        {
        }
    }
}
