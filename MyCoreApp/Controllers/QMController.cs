using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyCoreApp.Controllers;
using System;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MyCoreApp.Controllers
{
    
    [Route("api/[controller]")]
	[ApiController]
	//[Route("api/v1/QMController")]
	public class QMController : ControllerBase
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

		[HttpGet("api/qmcontroller/index")]
		public IActionResult Index()
		{
			List<QMPerson> personRead = new List<QMPerson>();
			QMPerson[] people = new QMPerson[4];
			people[0] = new QMPerson("Ali", 30);
			people[1] = new QMPerson("Bindu", 25);
			people[2] = new QMPerson("Sidhu", 35);
			people[3] = new QMPerson("Sid", 36);

			foreach (QMPerson personItem in people) {

				for (int i = 0; i <= people.Length - 1; i++)
				{
					people[i] = new QMPerson(personItem?._Name, personItem._Age);
					personRead.Add(people[i]);
				}
			}
			
			
				return GetData();
				return PostData(personRead);
			
		}


			[HttpGet("api/qmcontroller/getdata")]
		public IActionResult GetData()
		{
			try
			{
				IEnumerable<QMPerson> response= _operation.GetQMOperations().ToArray();

				if (response != null)
					return Ok(new { Message = "Success" });
				else
					return null;

			}
			catch (Exception ex)
			{
				throw ex;

				Console.WriteLine(_logger.GetType().Name);
			}
			
		}

		[HttpGet("api/qmcontroller/postdata")]
		public IActionResult PostData([FromBody]  IEnumerable<QMPerson> persons)
		{
			try
			{

				IEnumerable<QMPerson> response = _operation.AddQMOperation(persons);
				if (response!=null)
					return Ok(new { Message = "Success" });
				else
					return null;
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

			ApiControllerInspector.ListApiEndpoints(typeof(QMController));
		}
	}
}
