namespace NKZSoft.FluentValidation.Options.Internal;

internal static class OptionsBuilderExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(
        this OptionsBuilder<TOptions> optionsBuilder)
        where TOptions : class
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);

        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(serviceProvider =>
        {
            var validator = serviceProvider.GetRequiredService<IValidator<TOptions>>();
            return new FluentValidationOptions<TOptions>(optionsBuilder.Name, validator);
        });
        return optionsBuilder;
    }

    public static OptionsBuilder<TOptions> BindConfiguration<TOptions>(
        this OptionsBuilder<TOptions> optionsBuilder,
        IConfiguration configuration,
        Action<BinderOptions>? configureBinder = null)
        where TOptions : class
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);
        ArgumentNullException.ThrowIfNull(configuration);

        optionsBuilder.Configure<IConfiguration>((opts, config) =>
        {
            configuration.Bind(opts, configureBinder);
        });
        optionsBuilder.Services.AddSingleton<IOptionsChangeTokenSource<TOptions>, ConfigurationChangeTokenSource<TOptions>>();
        return optionsBuilder;
    }
}
