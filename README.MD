<p align="center">
	<img src="https://copperwire.emzi0767.com/logo.png" alt="CopperWire for Discord" width="192" height="192">
</p>
<h1 align="center">
	CopperWire for Discord
</h1>
<p align="center">
	[![AppVeyor][11]][4]
	[![NuGet][12]][5]
	[![MyGet][13]][6]
	[![Discord][14]][7]
</p>

CopperWire is a simple, .NET Standard-compatible wrapper for [Discord API][9].

It's written in C#, with primary aims being ease of use, while maintaining rich feature set.

# Requirements
The library requires that you have proper SDKs for your targets installed. It is required that you use Visual Studio 
2017, at least Community edition, version 15.3 or newer.

We recommend targeting [.NET Core][10] rather than regular .NET Framework, due to the former being open-source, 
portable, and lightweight.

# Installation and usage
First you need to install the library. You can obtain the latest stable releases from [NuGet][5], or, if you're feeling 
adventurous, you can try the latest nightly builds from [MyGet][6].

# Documentation and examples
Complete documentation for the project can be found [right here][1], with a quick start guide available [here][2].

Complete example bots can be found in my [example bot repository][3].

# Questions?
If you need more help, you can come talk to me on [my Discord server][7]:

[![Emzi's Central Dispatch][8]][7]

[1]: https://copperwire.emzi0767.com/
[2]: https://copperwire.emzi0767.com/articles/getting_started/first_bot.html
[3]: https://github.com/Emzi0767/CopperWire-Examples
[4]: https://ci.appveyor.com/project/Emzi0767/copperwire-6g6vr/branch/master
[5]: https://nuget.org/packages/CopperWire
[6]: https://www.myget.org/gallery/copperwire-nightly
[7]: https://discord.gg/rGKrJDR
[8]: https://discordapp.com/api/guilds/207879549394878464/embed.png?style=banner2
[9]: https://discordapp.com/developers
[10]: https://www.microsoft.com/net/download/windows
[11]: https://img.shields.io/appveyor/ci/Emzi0767/copperwire-6g6vr/master.svg
[12]: https://img.shields.io/nuget/v/DSharpPlus.svg?style=for-the-badge&label=NuGet
[13]: https://img.shields.io/myget/dsharpplus-nightly/vpre/DSharpPlus.svg?style=for-the-badge&label=MyGet
[14]: https://img.shields.io/discord/207879549394878464.svg?style=for-the-badge&label=Discord
