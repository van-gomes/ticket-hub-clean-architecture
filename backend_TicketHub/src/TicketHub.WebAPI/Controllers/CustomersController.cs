using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.UseCases.CustomerUseCases;
using TicketHub.Application.UseCases.CustomerUseCases.Create;
using TicketHub.Application.UseCases.CustomerUseCases.GetAll;
using TicketHub.Application.UseCases.CustomerUseCases.GetById;

namespace TicketHub.WebAPI.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
    private readonly CreateCustomerUseCase _createCustomerUseCase;
    private readonly GetAllCustomersUseCase _getAllCustomersUseCase;
    private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;

    public CustomersController(
        CreateCustomerUseCase createCustomerUseCase,
        GetAllCustomersUseCase getAllCustomersUseCase,
        GetCustomerByIdUseCase getCustomerByIdUseCase)
    {
        _createCustomerUseCase = createCustomerUseCase;
        _getAllCustomersUseCase = getAllCustomersUseCase;
        _getCustomerByIdUseCase = getCustomerByIdUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        try
        {
            var customer = await _createCustomerUseCase.ExecuteAsync(request);
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