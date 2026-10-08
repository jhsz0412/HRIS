using FluentValidation;
using HRIS.Application.Common.Behaviors;
using HRIS.Application.Common.Interfaces;
using HRIS.Application.Employees.CreateEmployee;
using HRIS.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(CreateEmployeeCommand).Assembly));

builder.Services.AddValidatorsFromAssembly(
    typeof(CreateEmployeeCommand).Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

builder.Services.AddEndpointsApiExplorer();
//Ordering API
builder.Services.AddSwaggerGen(options =>
{
    options.TagActionsBy(api =>
    {
        var controller = api.ActionDescriptor.RouteValues["controller"];

        return controller switch
        {
            "Authentication" => ["Authentication"],
            "Companies" => ["Organizations"],
            "Departments" => ["Organizations"],
            "Groups" => ["Organizations"],
            "Positions" => ["Organizations"],
            "EmploymentTypes" => ["Organizations"],
            "EmployeeStatuses" => ["Organizations"],
            "Employees" => ["Employees"],
            _ => ["Other"]
        };
    });

    options.OrderActionsBy(api =>
    {
        var controller = api.ActionDescriptor.RouteValues["controller"];

        return controller switch
        {
            "Authentication" => "01",
            "Companies" => "02",
            "Departments" => "02",
            "Groups" => "02",
            "Positions" => "02",
            "EmploymentTypes" => "02",
            "EmployeeStatuses" => "02",
            "Employees" => "03",
            _ => "99"
        };
    });
});
//End Ordering API

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
