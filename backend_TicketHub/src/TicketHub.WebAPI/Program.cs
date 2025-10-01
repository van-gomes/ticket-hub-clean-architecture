using TicketHub.Application.Interfaces;
using TicketHub.Application.UseCases.CustomerUseCases.GetAll;
using TicketHub.Application.UseCases.CustomerUseCases.GetById;
using TicketHub.Application.UseCases.PartnerUseCases.GetById;
using TicketHub.Application.UseCases.PartnerUseCases.Create;
using TicketHub.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Repositories
builder.Services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
//builder.Services.AddScoped<IPartnerRepository, FakePartnerRepository>();

// UseCases - Customer
builder.Services.AddScoped<GetAllCustomersUseCase>();
builder.Services.AddScoped<GetCustomerByIdUseCase>();

// UseCases - Partner
// builder.Services.AddScoped<GetAllPartnersUseCase>();
// builder.Services.AddScoped<GetPartnerByIdUseCase>();
// builder.Services.AddScoped<CreatePartnerUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapControllers(); 

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}