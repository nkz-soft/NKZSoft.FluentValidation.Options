namespace NKZSoft.FluentValidation.Options.Tests.Common;

using Microsoft.Extensions.Configuration;

public sealed class QueryTestFixture
{
    public IConfiguration Configuration { get; }

    public IServiceCollection Services { get; }

    public QueryTestFixture()
    {
        Services = new ServiceCollection();

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        Services.AddScoped<IConfiguration>(_ => Configuration);
    }
}
