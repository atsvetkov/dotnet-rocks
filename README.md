# dotnet-rocks

A simple extension .NET Core CLI tool extension for loading and playing [.NET Rocks!](https://www.dotnetrocks.com/) show episodes from command-line.

How to use:

1. add a .NET Core CLI tool reference to 'dotnet-rocks' package to the project file:
```
<ItemGroup>
    <DotNetCliToolReference Include="dotnet-rocks" Version="0.0.1" />
</ItemGroup>
```

2. run `dotnet restore`

After that `dotnet rocks` command should become available in the project:
```
> dotnet rocks
Pick one of 10 last episodes on .NET Rocks! to play:
 -16 Feb 2017: Fusion Power Update Geek Out
 -15 Feb 2017: Virtual, Augmented and Mixed Realities with Jessica Engstrom
 -14 Feb 2017: Machine Learning Panel at NDC London
 -09 Feb 2017: Ops and Operability with Dan North
 -08 Feb 2017: Xamarin MVVM apps with Gill Cleeren
 -07 Feb 2017: Chatbots with Galiya Warrier
 -02 Feb 2017: IdentityServer4 with Brock Allen and Dominick Baier
 -01 Feb 2017: Data and Docker with Stephanie Locke
 -31 Jan 2017: Nodatime, Google Cloud and More with Jon Skeet
 -26 Jan 2017: Punishment Driven Development with Louise Elliott
```

Accepts a number of episodes to display as the only command-line argument (default is 10):
```
> dotnet rocks 2
Pick one of 2 last episodes on .NET Rocks! to play:
 -16 Feb 2017: Fusion Power Update Geek Out
 -15 Feb 2017: Virtual, Augmented and Mixed Realities with Jessica Engstrom
```

After selecting the episode the tool will try to open a URL to the episode's MP3 record, which should trigger the default OS browser to handle this.

All credits for the most awesome podcast about technology go to [Carl Franklin](https://twitter.com/carlfranklin) and [Richard Campbell](https://twitter.com/richcampbell). Thanks guys, you are making us smarter!