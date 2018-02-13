using System;
using System.Net.Http;

namespace CopperWire.Http
{
    /// <summary>
    /// Represents a request ratelimit bucket, for use with HTTP ratelimiting.
    /// </summary>
    internal sealed class RequestBucket
    {
        /// <summary>
        /// Gets the ID of the channel attached to this bucket.
        /// </summary>
        public ulong ChannelId { get; }
        
        /// <summary>
        /// Gets the ID of the guild attached to this bucket.
        /// </summary>
        public ulong GuildId { get; }

        /// <summary>
        /// Gets the ID of the webhook attached to this bucket.
        /// </summary>
        public ulong WebhookId { get; }

        /// <summary>
        /// Gets the token attached to this bucket.
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Gets the route attached to this bucket.
        /// </summary>
        public string Route { get; }

        /// <summary>
        /// Gets the HTTP verb for this route.
        /// </summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// Gets or sets the number or remaining requests in this bucket.
        /// </summary>
        public int Remaining { get; set; }

        /// <summary>
        /// Gets or sets the number of maximum requests in this bucket.
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// Gets or sets the timestamp at which this bucket resets.
        /// </summary>
        public DateTimeOffset ResetsAt { get; set; }

        /// <summary>
        /// Gets the ID of this ratelimit bucket.
        /// </summary>
        public string Id
            => $"{this.Token}|{this.GuildId}|{this.ChannelId}|{this.WebhookId}|{this.Method.Method}|{this.Route}";

        /// <summary>
        /// Initializes this ratelimit bucket.
        /// </summary>
        /// <param name="channelId">ID of the channel attached to this bucket.</param>
        /// <param name="guildId">ID of the guild attached to this bucket.</param>
        /// <param name="webhookId">ID of the webhook attached to this bucket.</param>
        /// <param name="token">Token attached to this bucket.</param>
        /// <param name="method">Http verb attached to this bucket.</param>
        /// <param name="route">Route attached to this bucket.</param>
        public RequestBucket(ulong channelId, ulong guildId, ulong webhookId, string token, HttpMethod method, string route)
        {
            this.ChannelId = channelId;
            this.GuildId = guildId;
            this.WebhookId = webhookId;
            this.Token = token;
            this.Method = method;
            this.Route = route;
        }

        /// <summary>
        /// Returns a string representation of this bucket.
        /// </summary>
        /// <returns>String representation of this bucket.</returns>
        public override string ToString()
        {
            return $"Ratelimit bucket {this.Id} {this.Remaining}/{this.Maximum} {this.ResetsAt:yyyy-MM-dd HH:mm:ss}";
        }

        /// <summary>
        /// Returns a ratelimit bucket ID generated from supplied components.
        /// </summary>
        /// <param name="channelId">ID of the channel attached to the bucket.</param>
        /// <param name="guildId">ID of the guild attached to the bucket.</param>
        /// <param name="webhookId">ID of the webhook attached to the bucket.</param>
        /// <param name="token">Token attached to the bucket.</param>
        /// <param name="method">Http verb attached to the bucket.</param>
        /// <param name="route">Route attached to the bucket.</param>
        /// <returns>Generated ratelimit bucket ID.</returns>
        public static string GenerateId(ulong channelId, ulong guildId, ulong webhookId, string token, HttpMethod method, string route)
            => $"{token}|{guildId}|{channelId}|{webhookId}|{method.Method}|{route}";
    }
}
