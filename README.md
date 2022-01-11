# DemozooDotNet

[![Build status](https://ci.appveyor.com/api/projects/status/dg9d90baw6fgdnfg/branch/master?svg=true)](https://ci.appveyor.com/project/gsuberland/demozoodotnet-petnk/branch/master)

.NET API for Demozoo - http://demozoo.org/

This interface is not exhaustive, but it fetches most of the production and party data. Feature request issues and PRs welcome for improvements.

Written for .NET Standard with support for the following framework targets:

* .NET 6.0 (net6.0)
* .NET 5.0 (net5.0)
* .NET Core 3.1 (netcoreapp3.1)
* .NET Core 3.0 (netcoreapp3.0)
* .NET Core 2.1 (netcoreapp2.1)
* .NET Core 2.0 (netcoreapp2.0)
* .NET Standard 2.0 (netstandard2.1)
* .NET Standard 2.0 (netstandard2.0)
* .NET Framework 4.8 (net48)
* .NET Framework 4.7.2 (net472)
* .NET Framework 4.7.1 (net471)
* .NET Framework 4.6.2 (net462)
* .NET Framework 4.6.1 (net461)

Windows 10 and Ubuntu are officially supported.

## Dependencies

The only dependency is the [RestSharp](http://restsharp.org/) NuGet package.

## Tests

Tests are done with xUnit. The goal is to have 100% test coverage.

## Documentation

The easiest way to understand what data is available is to look at the API root - https://demozoo.org/api/v1/

## Examples

```c#
var prod = DemozooApi.GetProduction(123);
// print title
Console.WriteLine("Title: {0}", prod.Title);
// print platform(s) it was released on
Console.WriteLine("Platform: {0}", string.Join(", ", prod.Platforms.Select(plat => plat.Name)));

var party = DemozooApi.GetParty(456);
// print party name
Console.WriteLine("Name: {0}", party.Name);
// print location
Console.WriteLine("Location: {0} ({1}, {2})", party.Location, party.Latitude, party.Longitude);
```
