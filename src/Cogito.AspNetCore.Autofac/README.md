# Cogito.AspNetCore.Autofac

Wires Autofac into an ASP.NET Core host using the Cogito assembly-module convention.

## Why

Autofac's own ASP.NET Core integration wants you to name your modules. If your application is already
composed by scanning for assembly modules, you want the host to do the same — one call, and every
assembly contributes what it has.

## Install

```shell
dotnet add package Cogito.AspNetCore.Autofac
```

## Use

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseAutofac()
    .UseStartup<Startup>()
    .Build()
    .Run();
```

`UseAutofac` installs Autofac as the container and registers every assembly module it can find, so
services declared with `Cogito.Autofac` attributes are available without further wiring.

## License

MIT.
