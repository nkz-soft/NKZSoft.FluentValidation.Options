namespace NKZSoft.FluentValidation.Options.Tests.Validators;

internal sealed class TestTrueValidator : AbstractValidator<TestOptions>
{
    public TestTrueValidator()
    {
        RuleFor(x => x.BoolValue).Equal(true);
    }
}
