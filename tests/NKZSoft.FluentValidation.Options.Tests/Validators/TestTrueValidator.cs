namespace NKZSoft.FluentValidation.Options.Tests.Validators;

using Options;

internal sealed class TestTrueValidator : AbstractValidator<TestOptions>
{
    public TestTrueValidator()
    {
        RuleFor(x => x.BoolValue).Equal(true);
    }
}
