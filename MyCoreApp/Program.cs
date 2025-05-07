using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.OpenApi.Models;
using MyCoreApp;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



// Other startup code...


var app = builder.Build();

// Configure the HTTP request pipeline.


//void ConfigureServices(IServiceCollection services)
//{
	
//	services.AddEndpointsApiExplorer();
//	services.AddRouting();

//	services.AddSingleton<QMOperation>();
//	services.AddControllers();
//	services.AddSwaggerGen();
	

//	services.AddSwaggerGen(options =>
//	{

//		options.SwaggerDoc("v1", new OpenApiInfo
//		{
//			Title = "QMOperation - Catalog HTTP API",
//			Version = "v1",
//			Description = "The Microservice HTTP API"
//		});
//	});
//	// Add other services
//}



//void Configure(IApplicationBuilder app, Action<IEndpointRouteBuilder> configure)
//{

//	app.Run(async context => {
//		await context.Response.WriteAsync("Response from Run Middleware");
//	});

//	if (configure == null)
//	{
//		throw new ArgumentNullException(nameof(configure));
//	}
	


//	app.Use(async (context, next) =>
//	{
//		await context.Response.WriteAsync("Use Middleware1 Incoming Request\n");
//		await next();
//		await context.Response.WriteAsync("Use Middleware1 Outgoing Response\n");
//	});

//	app.Use(async (context, next) =>
//	{
//		await context.Response.WriteAsync("Use Middleware2 Incoming Request\n");
//		await next();
//		await context.Response.WriteAsync("Use Middleware2 Outgoing Response\n");
//	});

//	app.Run(async context => {
//		await context.Response.WriteAsync("Run Middleware3 Request Handled and Response Generated\n");
//	});


//	app.UseDeveloperExceptionPage();
//		app.UseSwagger();
	
//		app.UseSwaggerUI(c =>
//		{
//			c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//		});
	

//	app.UseHttpsRedirection();
//	app.UseStaticFiles();
//	app.UseRouting();

//	app.UseEndpoints(endpoints =>
//	{
//		endpoints.MapGet("/", async context =>
//		{
//			await context.Response.WriteAsync("Hello World!");
//		});

//		// Define other routes
//		endpoints.MapControllerRoute(
//			name: "default",
//			pattern: "{controller=QMController}/{action=Index}");
//	});


//	app.UseHttpsRedirection();

//	app.UseAuthorization();

//	app.UseCors();
//}

static void Main(string[] args)
{
	var builder = WebApplication.CreateBuilder(args);
	var services = builder.Services;

	// Add DbContext
	

	// Add Swagger services
	services.AddEndpointsApiExplorer();
	services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
	});

	// Add controllers
	services.AddControllers();

	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		// Enable Swagger UI
		app.UseDeveloperExceptionPage();
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			c.RoutePrefix = "https://localhost:5826/swagger";
		});
	}

	// Enable endpoint routing
	app.UseRouting();

	// Configure authentication and authorization
	app.UseAuthentication();
	app.UseAuthorization();

	// Map controllers
	app.MapControllers();

	app.Run();
}
    


