using Microsoft.AspNetCore.Mvc;

namespace MyCoreApp.Controllers
{
    [ApiController]
    //[Route("[controller]")]
	[Route("api/v1/[controller]")]
	public class QMController : ControllerBase
    {
      

        private readonly ILogger<QMController> _logger;

        public QMController(ILogger<QMController> logger)
        {
            _logger = logger;
        }


		[HttpGet(Name = "GetQMOperations")]
		public IEnumerable<QMPerson> GetQMOperations()
		{
            return GetQMOperations()
			.ToArray();
		}
	}
}
