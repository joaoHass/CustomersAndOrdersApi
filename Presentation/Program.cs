using Data;
using Domain.Customers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers(config => config.Filters.Add(new ProducesAttribute("application/json")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Customers and Orders",
        Version = "v1",
        Description = "An api that I'm developing for portfolio purposes",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Name = "João Hass",
            Email = "joaopedrohass@Outlook.com",
            Url = new Uri("https://github.com/joaoHass"),
        }
    });
});

var app = builder.Build();
app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
