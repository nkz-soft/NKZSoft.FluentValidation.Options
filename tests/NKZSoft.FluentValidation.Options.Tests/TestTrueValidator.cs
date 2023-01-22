namespace NKZSoft.FluentValidation.Options.Tests;

internal sealed class TestTrueValidator : AbstractValidator<TestOptions>
{
    public TestTrueValidator()
    {
        RuleFor(x => x.BoolValue).Equal(true);
    }
}
