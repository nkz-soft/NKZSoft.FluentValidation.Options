# NKZSoft.FluentValidation.Options

[![Nuget](https://img.shields.io/nuget/v/NKZSoft.FluentValidation.Options?style=plastic)](https://www.nuget.org/packages/NKZSoft.FluentValidation.Options/)

Provides validation to strongly typed configuration objects using FluentValidation library

I've been actually inspired by this article "[Adding validation to strongly typed configuration objects using FluentValidation](https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-using-flentvalidation/)" to create this project.

## Using
```csharp
public class TestOptionsValidator : AbstractValidator<TestOptions> {
    // ...
}

services.AddWithValidation<TestOptions, TestOptionsValidator>(configuration.GetSection("TestOptions"));
var options = serviceProvider.GetRequiredService<IOptions<TestOptions>>();

try
{
    options.Invoking(x => x.Value).Invoke();
}
catch (OptionsValidationException ex)
{
}
```
