using Microsoft.AspNetCore.Mvc;
using TicketHub.Application.UseCases.PartnerUseCases.Create;
using TicketHub.Application.UseCases.PartnerUseCases.GetById;

namespace TicketHub.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartnerController : ControllerBase
{
    private readonly CreatePartnerUseCase _createUseCase;
    private readonly GetPartnerByIdUseCase _getByIdUseCase;
    private readonly GetAllPartnersUseCase _getAllUseCase;

    public PartnerController(
        CreatePartnerUseCase createUseCase,
        GetPartnerByIdUseCase getByIdUseCase,
        GetAllPartnersUseCase getAllUseCase)
    {
        _createUseCase = createUseCase;
        _getByIdUseCase = getByIdUseCase;
        _getAllUseCase = getAllUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePartnerRequest request)
    {
        var input = new CreatePartnerInput(request.Name, request.Document);
        var result = await _createUseCase.ExecuteAsync(input);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getByIdUseCase.ExecuteAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllUseCase.ExecuteAsync();
        return Ok(result);
    }
}