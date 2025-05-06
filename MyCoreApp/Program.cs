using Microsoft.OpenApi.Models;
using MyCoreApp.WeatherForecast

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<QMOperation>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
	
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "QMOperation - Catalog HTTP API",
		Version = "v1",
		Description = "The Microservice HTTP API"
	});
});

// Other startup code...


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
	});
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
