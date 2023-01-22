namespace NKZSoft.FluentValidation.Options.Tests;

internal sealed class TestFalseValidator : AbstractValidator<TestOptions>
{
    public TestFalseValidator()
    {
        RuleFor(x => x.BoolValue).Equal(false);
    }
}
