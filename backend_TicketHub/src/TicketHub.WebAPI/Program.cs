using TicketHub.Application.Interfaces;
using TicketHub.Application.UseCases.CustomerUseCases.Create;
using TicketHub.Application.UseCases.CustomerUseCases.GetAll;
using TicketHub.Application.UseCases.CustomerUseCases.GetById;
using TicketHub.Application.UseCases.PartnerUseCases.Create;
using TicketHub.Application.UseCases.PartnerUseCases.GetById;
using TicketHub.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Swagger e Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositórios
builder.Services.AddSingleton<ICustomarRepository, FakeCustomerRepository>();
builder.Services.AddSingleton<IPartnerRepository, FakePartnerRepository>();

// UseCases - Customer
builder.Services.AddScoped<CreateCustomerUseCase>();
builder.Services.AddScoped<GetAllCustomersUseCase>();
builder.Services.AddScoped<GetCustomerByIdUseCase>();

// UseCases - Partner
//builder.Services.AddScoped<CreatePartnerUseCase>();
//builder.Services.AddScoped<GetAllPartnersUseCase>();
//builder.Services.AddScoped<GetPartnerByIdUseCase>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();