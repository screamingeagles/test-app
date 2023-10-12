using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using test_app.Model;
using test_app.Service;

namespace test_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyMembersController : Controller
    {
        private readonly ITransactions service;
        private readonly ILogger<StudentController> _logger;

        public FamilyMembersController(ILogger<StudentController> logger, ITransactions service)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFamily(int id)
        {            
            try
            {
                FamilyObject fo = service.GetFamilyMember(id);
                
                string json = JsonConvert.SerializeObject(
                       fo,
                       Newtonsoft.Json.Formatting.Indented,
                       new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                return Ok(json);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Getting Student or family details for ID: {id}");
            }
        }

        [HttpGet]
        [Route("{id}/Nationality/{countryId}")]
        public FamilyObject GetFamilyMembers(int id, int countryId)
        {
            // Gets a nationality associated with a family member
            // [GET] /api/FamilyMembers/{id}/Nationality/{id}

            _logger.LogInformation("GET API called at:" + DateTime.Now);

            return service.GetFamilyMembers(id, countryId);
        }


        [HttpPut]
        [Route("{id}")]
        [Route("{id}/Nationality/{countryId}")]
        public IActionResult UpdateFamilyMembers(int id, int? countryId, FamilyObject obj)
        {
            // Updates a particular Family Member
            // [PUT] /api/FamilyMembers/{id}

            // Updates a particular Family Member’s Nationality
            // [PUT] /api/FamilyMembers/{id}/Nationality/{id}

            _logger.LogInformation($"PUT API called for updating Family Members at: {DateTime.Now}");

            if (id != obj.ID)
                return BadRequest("Family Member ID do not Match");

            try
            {
                FamilyObject res = new FamilyObject();
                if (countryId.HasValue)
                {
                    res = service.UpdateFamilyMemberNationality(id, countryId.Value);
                }
                else
                {
                    res = service.UpdateFamilyMember(id, obj);
                }
                
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
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating Family Members for id: {id}");
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFamilyMembers(int id)
        {
            // Deletes a family member for a particular Student
            // [DELETE] /api/FamilyMembers/{id}
            
            _logger.LogInformation($"DELETE API called for Deleting Family Members at: {DateTime.Now}");
                       
            try
            {
                int res = service.DeleteFamilyMember(id);
                if (res > 0 ) {
                    return Ok("Success");
                }
                else
                {
                    return BadRequest("Invalid Data Provided");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting Family Members for id: {id}");
            }
        }

        [HttpGet]
        [Route("List/{id}")]
        public IEnumerable<FamilyObject> GetFamilyList(int id)
        {
            try
            {
                return service.GetFamilyMembersList(id);
            }
            catch (Exception)
            {
                _logger.LogError($"Error Getting family List for Student ID: {id}");
                return null;
                    
            }
        }
    }
}
