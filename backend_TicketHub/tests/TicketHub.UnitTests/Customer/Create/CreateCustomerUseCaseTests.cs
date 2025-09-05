using FluentValidation.TestHelper;
using TicketHub.Application.DTOs;
using TicketHub.Application.Validators;

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
        var model = new CreateCustomerRequest
        {
            Name = name,
            Email = "test@example.com",
            Cpf = "12345678901"
        };

        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Theory]
    [InlineData("invalidemail")]
    [InlineData("@missingusername.com")]
    public void InvalidEmail_ShouldHaveValidationError(string email)
    {
        var model = new CreateCustomerRequest
        {
            Name = "Valid Name",
            Email = email,
            Cpf = "12345678901"
        };

        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(c => c.Email);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("1234567")]
    [InlineData("abcdefghijk")]
    public void InvalidCpf_ShouldHaveValidationError(string cpf)
    {
        var model = new CreateCustomerRequest
        {
            Name = "Valid Name",
            Email = "test@example.com",
            Cpf = cpf
        };

        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(c => c.Cpf);
    }

    [Fact]
    public void ValidCustomer_ShouldNotHaveValidationErrors()
    {
        var model = new CreateCustomerRequest
        {
            Name = "Valid Name",
            Email = "test@example.com",
            Cpf = "12345678901"
        };

        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
