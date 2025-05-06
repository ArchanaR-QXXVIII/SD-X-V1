using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyCoreApp.Controllers
{
    
    [Route("api/[controller]")]
	[ApiController]
	//[Route("api/v1/QMController")]
	public class QMController : ControllerBase
    {
      

        private readonly ILogger<QMController> _logger;

        public QMController(ILogger<QMController> logger)
        {
            _logger = logger;
        }


		[HttpGet("QMOperations")]
		public IEnumerable<QMPerson> GetQMOperations()
        {
            try
            {
                return GetQMOperations()
            .ToArray();


            }
            catch (Exception ex)
            {
                throw ex;

                _logger.Log("GetQMOperations");
            }



        }
    }
}
