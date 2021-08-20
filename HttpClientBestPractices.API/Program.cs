using HttpClientBestPractices.API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;

var configuration = GetConfiguration();

try
{
    var host = BuildWebHost(configuration, args);
    host.Run();
    return 0;
}
catch (Exception ex)
{
    return 1;
}

IWebHost BuildWebHost(IConfiguration configuration, string[] args)
    => WebHost.CreateDefaultBuilder(args)
        .CaptureStartupErrors(false)
        .ConfigureKestrel(options =>
        {
            options.Listen(IPAddress.Any, 5001, listenOptions => { listenOptions.Protocols = HttpProtocols.Http1AndHttp2; });
        })
        .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
        .UseStartup<Startup>()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .Build();

IConfiguration GetConfiguration()
    => new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();