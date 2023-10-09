using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using test_app.Service;

namespace test_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalitiesController : Controller
    {
        private readonly ITransactions service;
        private readonly ILogger<StudentController> _logger;

        public NationalitiesController(ILogger<StudentController> logger, ITransactions service)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<NationalityObject> Index()
        {
            _logger.LogInformation("GET API called at:" + DateTime.Now);

            return service.GetAllNationalities();
        }

        [HttpPost]     
        public IActionResult AddNationality(NationalityObject obj)
        {
            // creates a new Country
            NationalityObject res = service.AddCountry(obj);
            if (res == null)
            {
                return BadRequest("Invalid Data Provided");
            }
            else
            {
                string json = JsonConvert.SerializeObject(
                    res,
                    Newtonsoft.Json.Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return Ok(json);
            }
        }
    }
}
