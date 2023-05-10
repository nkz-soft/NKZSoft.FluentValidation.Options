# NKZSoft.FluentValidation.Options

[![Nuget](https://img.shields.io/nuget/v/NKZSoft.FluentValidation.Options?style=plastic)](https://www.nuget.org/packages/NKZSoft.FluentValidation.Options/)

Provides validation to strongly typed configuration objects using FluentValidation library

I've been actually inspired by this article "[Adding validation to strongly typed configuration objects using FluentValidation](https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-using-flentvalidation/)" to create this project.

## Using

First let's add a validator:
```csharp
public class TestOptionsValidator : AbstractValidator<TestOptions> {
    // ...
}
```
There are two ways to configure it via a configuration file:
```csharp
services.AddWithValidation<TestOptions, TestOptionsValidator>(configuration.GetSection("TestOptions"));
```
or via Action:
```csharp
services.AddWithValidation<TestOptions, TestOptionsValidator>(options => 
{
    options.BoolValue = true;
});
```
And check that everything works:
```csharp
var options = serviceProvider.GetRequiredService<IOptions<TestOptions>>();

try
{
    options.Invoking(x => x.Value).Invoke();
}
catch (OptionsValidationException ex)
{
}
```
