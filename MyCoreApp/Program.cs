using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppMiddleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



// Other startup code...
//private readonly IConfiguration Configuration { get; set; }
void Startup(IConfiguration configuration)
{
	Configuration = configuration;
}


// This method gets called by the runtime. Use this method to add services to the container.
void ConfigureServices(IServiceCollection services)
{
	services.AddControllersWithViews();
}

void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
	// ...
	app.UseRouter(BuildRouter(app));
	// ...
	app.UseMvc();
}
IRouter BuildRouter(IApplicationBuilder applicationBuilder)
{
	var builder = new RouteBuilder(applicationBuilder);

	// use middlewares to configure a route
	builder.MapMiddlewareGet("/api/v1", appBuilder => {
		appBuilder.Use(Middleware1);
		appBuilder.Use(Middleware2);
		//appBuilder.Use(RequestValidationMiddleware);
		appBuilder.UseMvc();          // use a MVC here ...
	});

	builder.MapMiddlewarePost("/api/v1", appBuilder => {
		appBuilder.Use(Middleware1);

		//appBuilder.Use(Middleware2);
		//appBuilder.Use(RequestValidationMiddleware);
		appBuilder.UseMvc();
	});
	// ....

	return builder.Build();
}



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
			c.RoutePrefix = "https://localhost:5000/index/id";
		});

		

	}


	//app.UseApiLog();
	app.Map("/api", ApiLogApps);
	app.Map("/exlog", ExceptionLogApps);

	// Enable endpoint routing
	app.UseRouting();
	app.UseEndpoints(endpoints =>
	{
		endpoints.MapGet("/", async context =>
		{
			await context.Response.WriteAsync("Hello World!");
		});

		// Define other routes
		endpoints.MapControllerRoute(
			name: "default",
			pattern: "{controller=QMController}/{action=Index}/{id:int}");
	});
	// Configure authentication and authorization
	app.UseAuthentication();
	app.UseAuthorization();

	app.UseEndpoints(endpoints =>
	{
		endpoints.MapControllers();
	});
	app.Run();
}

static void ApiLogApps(IApplicationBuilder app)
{
	//app.Run(() => )
	app.UseApiLog();
	app.UseMvc();
}

