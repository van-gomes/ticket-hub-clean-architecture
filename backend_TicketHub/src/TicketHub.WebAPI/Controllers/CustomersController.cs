using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.UseCases.CustomerUseCases;

namespace TicketHub.WebAPI.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateCustomerRequest request)
    {
        var useCase = new CreateCustomerUseCase();

        try
        {
            var customer = CreateCustomerUseCase.Execute(request);
            return Created("", customer);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            return UnprocessableEntity(new { Errors = errors });
        }
    }
}
