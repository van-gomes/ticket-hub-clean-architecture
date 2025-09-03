using FluentValidation.TestHelper;
using TicketHub.Application.Validators;
using TicketHub.Domain.Entities;
using Xunit;

namespace TicketHub.Tests;

public class CustomerValidatorTests
{
    private readonly CustomerValidator _validator;

    public CustomerValidatorTests()
    {
        _validator = new CustomerValidator();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    public void InvalidName_ShouldHaveValidationError(string name)
    {
        var model = new Customer(name, "test@example.com", "12345678901");
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Theory]
    [InlineData("invalidemail")]
    [InlineData("missing@dot")]
    [InlineData("@missingusername.com")]
    public void InvalidEmail_ShouldHaveValidationError(string email)
    {
        var model = new Customer("Valid Name", email, "12345678901");
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(c => c.Email);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("1234567")]
    public void InvalidCpf_ShouldHaveValidationError(string cpf)
    {
        var model = new Customer("Valid Name", "test@example.com", cpf);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(c => c.Cpf);
    }

    [Fact]
    public void ValidCustomer_ShouldNotHaveValidationErrors()
    {
        var model = new Customer("Valid Name", "test@example.com", "12345678901");
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}