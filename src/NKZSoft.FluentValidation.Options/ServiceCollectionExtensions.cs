namespace NKZSoft.FluentValidation.Options;

using Internal;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register this options instance for validation of an registered <see cref="IValidator{TOptions}"/> in service container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The configuration section to validate.</param>
    /// <param name="configureBinder">Optional. Used to configure the <see cref="BinderOptions"/>.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <typeparam name="TValidator">The validator type that defines a validator for a particular type.</typeparam>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that additional calls can be chained.</returns>
    public static OptionsBuilder<TOptions> AddWithValidation<TOptions, TValidator>(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<BinderOptions>? configureBinder = null)
        where TOptions : class
        where TValidator : class, IValidator<TOptions>
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddScoped<IValidator<TOptions>, TValidator>();

        return services.AddOptions<TOptions>()
            .BindConfiguration(configuration, configureBinder)
            .ValidateFluentValidation()
            .ValidateOnStart();
    }
}
