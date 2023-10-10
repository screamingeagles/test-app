using Microsoft.AspNetCore.Mvc;
using test_app.Service;
using test_app.Model;
using Newtonsoft.Json;
using Azure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace test_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ITransactions service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, ITransactions service)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StudentObject> GetStudents()
        {
            _logger.LogInformation("GET API called at:" + DateTime.Now);

            return service.GetStudents();
        }

        [HttpPost]
        [Route("")]                     // same controller but will only add student
        public IActionResult PostStudent(StudentObject obj)
        {
            // Add a new Student with Basic Details Only
            // [POST] /api/Students

            StudentObject res = service.AddStudent(obj);
            if (res == null) {
                return BadRequest("Invalid Data Provided");
            }
            else {
                string json = JsonConvert.SerializeObject(
                    res,
                    Newtonsoft.Json.Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return Ok(json);
            }
        }

        [HttpPost]
        [Route("{id}/FamilyMembers")]   // same controller but will add family member
        public IActionResult PostStudentFamily(int? id, FamilyObject obj)
        {
            // Creates a new Family Member for a particular Student(without the nationality)
            // [POST] /api/Students/{id}/FamilyMembers/
            
            _logger.LogInformation($"PUT API called for Adding Student Family at: {DateTime.Now}");

            if (id.HasValue == false)
                return BadRequest("Student ID Not Found");

            FamilyObject res = service.AddFamilyMember(id.Value, obj);            
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


        [HttpPut]
        [Route("{id}")]
        [Route("{id}/Nationality/{countryId}")]
        public IActionResult UpdateStudent(int id, int? countryId, StudentObject obj)
        {
            // Updates a Student’s Basic Details only
            // [PUT] /api/Students/{id}

            // Updates a Student’s Nationality
            // [PUT] /api/Students/{id}/Nationality/{id}

            _logger.LogInformation($"PUT API called for updating at: {DateTime.Now}");

            if (id != obj.ID)
                return BadRequest("Student ID do not Match");

            try
            {
                StudentObject res = service.UpdateStudent(obj, countryId);
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data for id: {id}");
            }

        }

        [HttpGet]
        [Route("{id}")]
        [Route("{id}/{prop}")]
        public IActionResult GetStudent(int id, string prop = "")
        {
            // Gets the Nationality of a particular student
            // [GET] /api/Students/{id}/Nationality

            // Gets Family Members for a particular Student
            // [GET] /api/Students/{id}/FamilyMembers
            
            string json = String.Empty;
            try
            {
                switch (prop)
                {
                    case "Nationality":
                        StudentObject res = service.GetStudent(id, false, true);
                        json = JsonConvert.SerializeObject(
                               res,
                               Newtonsoft.Json.Formatting.Indented,
                               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        break;

                    case "FamilyMembers":
                        IEnumerable<FamilyObject> arr = service.GetStudentFamilyMembers(id);
                        json = JsonConvert.SerializeObject(
                               arr,
                               Newtonsoft.Json.Formatting.Indented,
                               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        break;

                    default:
                        StudentObject std = service.GetStudent(id, true, true);
                        json = JsonConvert.SerializeObject(
                               std,
                               Newtonsoft.Json.Formatting.Indented,
                               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        break;
                }
               
                return Ok(json);
            }
            catch (Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Getting Student or family details for ID: {id}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {            
            _logger.LogInformation($"DELETE API called for Deleting Student at: {DateTime.Now}");
            try {
                int res = service.DeleteStudent(id);
                if (res > 0) {
                    return Ok("Success");
                }
                else {
                    return BadRequest("Invalid Data Provided");
                }
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting Student id: {id}");
            }
        }

    }
}
