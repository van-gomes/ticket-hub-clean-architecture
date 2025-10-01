using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.UseCases.CustomerUseCases;
using TicketHub.Application.UseCases.CustomerUseCases.GetAll;
using TicketHub.Application.UseCases.CustomerUseCases.GetById;

namespace TicketHub.WebAPI.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
    private readonly GetAllCustomersUseCase _getAllCustomersUseCase;
    private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;
    
    public CustomersController(GetAllCustomersUseCase getAllCustomersUseCase,
        GetCustomerByIdUseCase getCustomerByIdUseCase)
    {
        _getAllCustomersUseCase = getAllCustomersUseCase;
        _getCustomerByIdUseCase = getCustomerByIdUseCase;
    }

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
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _getAllCustomersUseCase.ExecuteAsync();
        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customer = await _getCustomerByIdUseCase.ExecuteAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }
}
