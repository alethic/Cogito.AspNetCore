# Cogito.AspNetCore

A reverse proxy middleware for ASP.NET Core, plus small helpers around hosting and `PathString`.

## Why

Putting a legacy application behind a new one usually means standing up nginx or IIS ARR beside the
app. When all you need is "these paths go to that server, and rewrite the links that come back", a
middleware in the pipeline is far less to operate — and it can share the app's configuration and
authentication.

## Install

```shell
dotnet add package Cogito.AspNetCore
```

## Proxying

```csharp
app.UseReverseProxyMiddleware(options =>
{
    options.Prefix = "/legacy";
    options.Target = new Uri("http://legacy.internal/");
});
```

`UseReverseProxyRewrite` handles the other half — rewriting absolute URLs in proxied responses so
links and redirects point back through the proxy instead of at the origin.

## Hosting

`BuildAndRunAsync` builds and runs a host in one call, with cancellation handled. `EndsWithSegments`
completes `PathString`'s `StartsWithSegments` for matching at the end of a path.

## License

MIT.
