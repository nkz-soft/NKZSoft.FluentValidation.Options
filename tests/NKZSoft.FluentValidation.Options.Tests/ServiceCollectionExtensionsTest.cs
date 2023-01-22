namespace NKZSoft.FluentValidation.Options.Tests;

using Common;

[Collection("QueryCollection")]
public class ServiceCollectionExtensionsTest
{
    private readonly QueryTestFixture _fixture;

    public ServiceCollectionExtensionsTest(QueryTestFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        _fixture = fixture;
    }

    [Fact]
    public void ValidateOptionSuccessfully()
    {
        _fixture.Services.AddWithValidation<TestOptions, TestTrueValidator>(_fixture.Configuration.GetSection("TestOptions"));

        using var serviceProvider = _fixture.Services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<TestOptions>>();

        options.Value.BoolValue.Should().BeTrue();
    }

    [Fact]
    public void ValidateOptionError()
    {
        _fixture.Services.AddWithValidation<TestOptions, TestFalseValidator>(_fixture.Configuration.GetSection("TestOptions"));

        using var serviceProvider = _fixture.Services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<TestOptions>>();

        options.Invoking(x => x.Value)
            .Should().Throw<OptionsValidationException>()
            .And
            .OptionsType.Should().Be(typeof(TestOptions));
    }
}
