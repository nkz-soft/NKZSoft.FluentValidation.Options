namespace NKZSoft.FluentValidation.Options.Tests;

using Common;
using Options;
using Validators;

[Collection(nameof(TrueValidatorCollection))]
public class TrueValidatorTest
{
    private readonly QueryTestFixture _fixture;

    public TrueValidatorTest(QueryTestFixture fixture)
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
}
