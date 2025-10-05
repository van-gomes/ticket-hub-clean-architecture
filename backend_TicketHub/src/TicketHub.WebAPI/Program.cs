using TicketHub.Application.Interfaces;
using TicketHub.Application.UseCases.CustomerUseCases.Create;
using TicketHub.Application.UseCases.CustomerUseCases.GetAll;
using TicketHub.Application.UseCases.CustomerUseCases.GetById;
using TicketHub.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Adiciona serviços MVC e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aqui estão os registros necessários de injeção
//builder.Services.AddScoped<ICustomarRepository, FakeCustomerRepository>();

builder.Services.AddSingleton<ICustomarRepository, FakeCustomerRepository>();

builder.Services.AddScoped<CreateCustomerUseCase>();
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