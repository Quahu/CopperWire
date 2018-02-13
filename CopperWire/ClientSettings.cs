using System;
using System.Collections.Generic;
using System.Text;

namespace CopperWire
{
    /// <summary>
    /// Represents configuration options for <see cref="ClientBase"/> and its derived types.
    /// </summary>
    public class ClientBaseSettings
    {
        /// <summary>
        /// <para>Sets the token used to authenticate with Discord.</para>
        /// <para>By default, this value is set to <c>null</c>.</para>
        /// </summary>
        public string Token
        {
            get => this._token;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Token cannot be empty or all-whitespace.", nameof(value));

                this._token = value.Trim();
            }
        }
        private string _token = null;

        /// <summary>
        /// <para>Sets the type of the token used to authenticate with Discord.</para>
        /// <para>By default, this value is set to <see cref="TokenType.Bot"/>.</para>
        /// </summary>
        public TokenType TokenType { get; set; } = TokenType.Bot;
    }

    /// <summary>
    /// Represents additional configuration options for <see cref="Client"/>.
    /// </summary>
    public class ClientSettings : ClientBaseSettings
    { 
        /// <summary>
        /// <para>Sets whether the client should attempt reconnecting to Discord in the event of a connection loss.</para>
        /// <para>By default, this value is set to <c>true</c>.</para>
        /// </summary>
        public bool AutoReconnect { get; set; } = true;

        /// <summary>
        /// <para>Sets the compression mode employed when communicating with Discord over WebSocket.</para>
        /// <para>By default, this value is set to <see cref="GatewayCompressionMode.Stream"/>.</para>
        /// </summary>
        public GatewayCompressionMode CompressionMode { get; set; } = GatewayCompressionMode.Stream;

        /// <summary>
        /// <para>Sets the number of members at which guilds sent from Discord are considered large.</para>
        /// <para>Changing this setting will affect how members are sent by Discord.</para>
        /// <para>By default, this value is set to <c>250</c>.</para>
        /// </summary>
        public int LargeThreshold { get; set; } = 250;
    }

    /// <summary>
    /// Represents type of the token used to authenticate with Discord.
    /// </summary>
    public enum TokenType : int
    {
        /// <summary>
        /// Represents a bot user token. In most cases, this is the token type you need.
        /// </summary>
        Bot = 0,

        /// <summary>
        /// Represents a bearer user token, obtained from OAuth2. This is used to create Discord-integrated applications.
        /// </summary>
        Bearer = 1
    }

    /// <summary>
    /// Represents compression mode for WebSocket data when communicating with Discord.
    /// </summary>
    public enum GatewayCompressionMode : int
    {
        /// <summary>
        /// Specifies that no compression should be applied. This is highly unrecommended.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that compression should be applied on payload level. This is old and unrecommended mode.
        /// </summary>
        Payload = 1,

        /// <summary>
        /// Specifies that compression should be applied on stream level. This is the recommended mode.
        /// </summary>
        Stream = 2
    }
}
