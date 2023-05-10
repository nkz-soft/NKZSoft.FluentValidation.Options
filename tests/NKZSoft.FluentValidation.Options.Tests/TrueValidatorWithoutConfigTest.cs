namespace NKZSoft.FluentValidation.Options.Tests;

using Common;
using Options;
using Validators;

[Collection(nameof(TrueValidatorCollection))]
public class TrueValidatorWithoutConfigTest
{
    private readonly QueryTestFixture _fixture;

    public TrueValidatorWithoutConfigTest(QueryTestFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        _fixture = fixture;
    }

    [Fact]
    public void ValidateOptionSuccessfully()
    {
        _fixture.Services.AddWithValidation<TestOptions, TestTrueValidator>(options =>
        {
            options.BoolValue = true;
        });

        using var serviceProvider = _fixture.Services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<TestOptions>>();

        options.Value.BoolValue.Should().BeTrue();
    }

    [Fact]
    public void ValidateOptionError()
    {
        _fixture.Services.AddWithValidation<TestOptions, TestFalseValidator>(options =>
        {
            options.BoolValue = true;
        });

        using var serviceProvider = _fixture.Services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<TestOptions>>();

        options.Invoking(x => x.Value)
            .Should().Throw<OptionsValidationException>()
            .And
            .OptionsType.Should().Be(typeof(TestOptions));
    }
}
