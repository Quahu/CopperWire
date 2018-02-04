<p align="center">
	<img src="https://copperwire.emzi0767.com/logo.png" alt="CopperWire for Discord" width="192" height="192">
</p>
<h1 align="center">
	CopperWire for Discord
</h1>
<p align="center">
	<a href="https://ci.appveyor.com/project/Emzi0767/copperwire"><img src="https://img.shields.io/appveyor/ci/Emzi0767/copperwire.svg?style=for-the-badge" alt="Discord"></a>
	<a href="https://nuget.org/packages/CopperWire"><img src="https://img.shields.io/nuget/v/CopperWire.svg?style=for-the-badge&label=NuGet" alt="Discord"></a>
	<a href="https://www.myget.org/gallery/copperwire-nightly"><img src="https://img.shields.io/myget/copperwire-nightly/vpre/CopperWire.svg?style=for-the-badge&label=MyGet" alt="Discord"></a>
	<a href="https://discord.gg/rGKrJDR"><img src="https://img.shields.io/discord/207879549394878464.svg?style=for-the-badge&label=Discord" alt="Discord"></a>
</p>

CopperWire is a simple, .NET Standard-compatible wrapper for [Discord API][9].

It's written in C#, with primary aims being ease of use, while maintaining rich feature set.

## Requirements
The library requires that you have proper SDKs for your targets installed. It is required that you use Visual Studio 
2017, at least Community edition, version 15.3 or newer.

We recommend targeting [.NET Core][10] rather than regular .NET Framework, due to the former being open-source, 
portable, and lightweight.

Aside from that, you are required to know C# on at least intermediate level before attempting to use the library. I 
will not take any time to explain language basics to you, and if you come to me without understanding the language, I 
will simply redirect you to [the C# guide][11].

### Building
Building CopperWire from source is possible on both Windows and GNU/Linux operating systems. For more detailed 
instructions, check out the [building guide][12].

## Installation and usage
First you need to install the library. You can obtain the latest stable releases from [NuGet][5], or, if you're feeling 
adventurous, you can try the latest nightly builds from [MyGet][6].

## Documentation and examples
Complete documentation for the project can be found [right here][1], with a quick start guide available [here][2].

Complete example bots can be found in my [example bot repository][3].

## Questions?
If you need more help, you can come talk to me on [my Discord server][7]:

[![Emzi's Central Dispatch][8]][7]

[1]: https://copperwire.emzi0767.com/
[2]: https://copperwire.emzi0767.com/articles/getting_started/first_bot.html
[3]: https://github.com/Emzi0767/CopperWire-Examples
[4]: https://ci.appveyor.com/project/Emzi0767/copperwire/branch/master
[5]: https://nuget.org/packages/CopperWire
[6]: https://www.myget.org/gallery/copperwire-nightly
[7]: https://discord.gg/rGKrJDR
[8]: https://discordapp.com/api/guilds/207879549394878464/embed.png?style=banner2
[9]: https://discordapp.com/developers
[10]: https://www.microsoft.com/net/download/windows
[11]: https://docs.microsoft.com/en-us/dotnet/csharp/
[12]: https://github.com/Emzi0767/CopperWire/blob/master/BUILDING.MD
