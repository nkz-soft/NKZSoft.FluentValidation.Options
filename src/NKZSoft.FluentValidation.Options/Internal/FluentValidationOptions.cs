namespace NKZSoft.FluentValidation.Options.Internal;

internal sealed class FluentValidationOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    private readonly IValidator<TOptions> _validator;
    private readonly string? _name;

    public FluentValidationOptions(string? name, IValidator<TOptions> validator)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(validator);

        _validator = validator;
        _name = name;
    }

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (_name == null || name == _name)
        {
            var validationResult = _validator.Validate(options);
            if (validationResult.IsValid)
            {
                return ValidateOptionsResult.Success;
            }

            return ValidateOptionsResult.Fail(
                validationResult.Errors.Select(error => error.ToString())
            );
        }
        return ValidateOptionsResult.Skip;
    }
}
