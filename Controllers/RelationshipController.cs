using Microsoft.AspNetCore.Mvc;
using test_app.Model;
using test_app.Service;

namespace test_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelationshipController : Controller
    {
        private readonly ITransactions service;
        private readonly ILogger<StudentController> _logger;

        public RelationshipController(ILogger<StudentController> logger, ITransactions service)
        {
            this.service = service;
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<RelationObject> Index()
        {
            _logger.LogInformation("GET API called for Relations at:" + DateTime.Now);

            return service.GetRelations();
        }
    }
}
