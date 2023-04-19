using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal static class HostConfiguration
{
    public static IHost CreateHost()
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureServices(services =>
        {
            services.AddSingleton<Benchmark>();
            services.AddSingleton<Test>();
            services.AddSingleton<SingletonService>();
            services.AddTransient<TransientSubscriber>();

        });

        return builder.Build();
    }
}




