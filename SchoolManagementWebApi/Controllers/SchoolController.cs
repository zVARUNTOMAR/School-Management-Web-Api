using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebApi.BussinessLayer;
using SchoolManagementWebApi.Entity;

namespace SchoolManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class SchoolController : Controller
    {
        private readonly ISchoolManagementBussinessLayer _schoolData;

        public SchoolController(ISchoolManagementBussinessLayer schoolData)
        {
            _schoolData = schoolData;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Show all Schools
        [HttpGet("ShowSchools")]
        public IActionResult ShowSchools()
        {
            return Ok(_schoolData.ShowSchools());
        }

        //Add New School
        [HttpPost("AddSchool")]
        public IActionResult AddSchool(School school)
        {
            _schoolData.AddSchool(school);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + school.SchoolId, school);
        }

        //Show School Record by Id
        [HttpGet("ShowSchoolRecord/{id}")]
        public IActionResult ShowSchoolRecord(int id)
        {
            var school = _schoolData.ShowSchoolRecord(id);

            if (school != null)
            {
                return Ok(school);
            }
            else
            {
                return NotFound($"School with Id : {id} was not found");
            }
        }

        //Update School
        [HttpPut("UpdateSchool/{id}")]
        public IActionResult UpdateSchool(int id, School school)
        {
            var existingSchool = _schoolData.ShowSchoolRecord(id);

            if (existingSchool != null)
            {
                school.SchoolId = existingSchool.SchoolId;
                _schoolData.UpdateSchool(school);
            }

            return Ok(school);
        }

        //DeletSchool
        [HttpDelete("DeleteSchool/{id}")]
        public IActionResult DeleteSchool(int id) {
            var existingSchool = _schoolData.ShowSchoolRecord(id);

            if (existingSchool != null) {
                _schoolData.DeleteSchool(id);
            }

            return Ok(id);
        }
    }
}