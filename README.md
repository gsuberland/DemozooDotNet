# DemozooDotNet

[![Build status](https://ci.appveyor.com/api/projects/status/dg9d90baw6fgdnfg/branch/master?svg=true)](https://ci.appveyor.com/project/gsuberland/demozoodotnet-petnk/branch/master)

.NET API for Demozoo - http://demozoo.org/

Written for .NET Standard, should work on both .NET Framework and .NET Core on all supported platforms.

This is currently a work in progress, but it fetches some data.

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
