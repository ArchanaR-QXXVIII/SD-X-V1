using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyCoreApp.Controllers;
using System;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MyCoreApp.Controllers
{
    
   
	[Route("api/[Controller]")]
	public class QMController : Controller
    {


		private readonly ApiControllerInspector _apiControllerInspector;

		private readonly ILogger<QMController> _logger;
		private readonly IQMOperation _operation;
		
		public QMController(IQMOperation operation, ILogger<QMController> logger, ApiControllerInspector apiControllerInspector)
        {
            _logger = logger;
            _operation = operation; //_person = person;
			_apiControllerInspector = apiControllerInspector;
		}

		[HttpGet("home/index/id")]
		public IActionResult Index(int id)
		{
			
			return GetData();
				return PostData(personRead);
			
		}


			[HttpGet("getdata")]
			public IActionResult GetData()
			{
			try
			{
				
				HttpResponseMessage response = await _operation.GetQMOperations().ToArray();

				if (response.IsSuccessStatusCode)
				{
					string data = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Data from API: " + data);
					return Ok(data);
				}
				else
				{
					Console.WriteLine("Error fetching data");
					return null;
				}

				
			}
			catch (Exception ex)
			{
				throw ex;

				Console.WriteLine(_logger.GetType().Name);
			}
			
		}

		[HttpPost("postdata")]
		public IActionResult PostData([FromBody]  IEnumerable<QMPerson> persons)
		{
			try
			{
				
				var client = _httpClientFactory.CreateClient();
				var request = new HttpRequestMessage(HttpMethod.Get, persons);

				// Optionally add headers
				request.Headers.Add("Accept", "application/json");
				HttpResponseMessage response = await _operation.AddQMOperation(persons).ToArray();

				if (response.IsSuccessStatusCode)
				{
					string data = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Data from API: " + data);
					return Ok(data);
				}
				else
				{
					Console.WriteLine("Error fetching data");
					return null;
				}
			}
			catch (Exception ex)
			{
				throw ex;

				Console.WriteLine(_logger.GetType().Name);
			}

		}


		
	}
	public class Program
	{
		//private readonly ApiControllerInspector;
		public static void Main(string[] args)
		{

			ApiControllerInspector.ListApiEndpoints(typeof(Controller));
		}
	}
}
