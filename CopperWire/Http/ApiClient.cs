using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CopperWire.Http
{
    /// <summary>
    /// Discord API client, used to handle requests made to Discord's API over HTTP.
    /// </summary>
    public sealed class ApiClient : IDisposable
    {
        /// <summary>
        /// Gets the <see cref="HttpClient"/> instance used to make requests to the API by this client.
        /// </summary>
        public HttpClient Http { get; }

        /// <summary>
        /// Gets the ratelimit buckets handled by this API client.
        /// </summary>
        private ConcurrentDictionary<string, RequestBucket> RatelimitBuckets { get; }

        /// <summary>
        /// Initializes the API client, with specified proxy settings, if any.
        /// </summary>
        /// <param name="proxy">Proxy settings to use for this API client. Specify <c>null</c> for no proxy.</param>
        public ApiClient(IWebProxy proxy = null)
        {
            this.Http = new HttpClient(new HttpClientHandler
            {
                UseCookies = false,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                UseProxy = proxy != null,
                Proxy = proxy
            })
            {
                BaseAddress = new Uri("https://discordapp.com/api/v7")
            };

            this.RatelimitBuckets = new ConcurrentDictionary<string, RequestBucket>();
        }

        /// <summary>
        /// Disposes this API client, and the underlying HTTP client.
        /// </summary>
        public void Dispose()
        {
            this.Http.Dispose();
        }
    }
}
