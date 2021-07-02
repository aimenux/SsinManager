# SsinManager
```
A global tool in order to generate or validate ssin depending on country
```

In this demo, i m providing a global tool in order to generate or validate ssin numbers depending on country.

The tool is based on multiple sub commmands :

> - Use sub command `Generate` to generate ssin
> - Use sub command `Validate` to validate ssin
>
> To run code in debug or release mode, type the following commands in your favorite terminal : 
> - `.\App.exe generate`
> - `.\App.exe generate -n 20 -c belgium`
> - `.\App.exe validate 60071320535`
> - `.\App.exe validate 60071320535 -c belgium`
>
> To install, run, update, uninstall global tool from a local source path, type commands :
> - `dotnet tool install -g --configfile .\Nugets\local.config SsinManager`
> - `SsinManager -h`
>
>
> To install global tool from [nuget source](https://www.nuget.org/packages/SsinManager), type these command :
> - `dotnet tool install -g SsinManager --ignore-failed-sources`
>

**`Tools`** : vs19, net 5.0