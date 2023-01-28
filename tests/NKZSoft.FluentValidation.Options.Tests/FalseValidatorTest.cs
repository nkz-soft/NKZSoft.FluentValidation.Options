namespace NKZSoft.FluentValidation.Options.Tests;

using Common;
using Validators;

[Collection(nameof(FalseValidatorCollection))]
public class FalseValidatorTest
{
    private readonly QueryTestFixture _fixture;

    public FalseValidatorTest(QueryTestFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        _fixture = fixture;
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
