# Cogito.AspNetCore

[![Build](https://github.com/alethic/Cogito.AspNetCore/actions/workflows/Cogito.AspNetCore.yml/badge.svg)](https://github.com/alethic/Cogito.AspNetCore/actions/workflows/Cogito.AspNetCore.yml)

A reverse proxy middleware for ASP.NET Core, for putting an existing application behind a new one without a separate proxy to operate.

## Packages

**[Cogito.AspNetCore](https://www.nuget.org/packages/Cogito.AspNetCore)** — A reverse proxy middleware for ASP.NET Core, plus small helpers around hosting and `PathString`.

**[Cogito.AspNetCore.Autofac](https://www.nuget.org/packages/Cogito.AspNetCore.Autofac)** — Wires Autofac into an ASP.NET Core host using the Cogito assembly-module convention.

Each package carries its own README with the detail; the links above go to nuget.org.

## Building

```shell
dotnet restore Cogito.AspNetCore.slnx
dotnet msbuild -p:Configuration=Release Cogito.AspNetCore.dist.msbuildproj
```

Packages are staged into `dist/nuget` and test suites into `dist/tests`; run a suite with
`dotnet test -f <tfm> <path to its assembly>`.

## License

MIT — see [LICENSE](LICENSE).
