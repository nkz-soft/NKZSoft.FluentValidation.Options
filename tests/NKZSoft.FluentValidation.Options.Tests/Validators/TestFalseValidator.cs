namespace NKZSoft.FluentValidation.Options.Tests.Validators;

using Options;

internal sealed class TestFalseValidator : AbstractValidator<TestOptions>
{
    public TestFalseValidator()
    {
        RuleFor(x => x.BoolValue).Equal(false);
    }
}
