using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementWebApi.Entity;
using SchoolManagementWebApi.BussinessLayer;
namespace SchoolManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ISchoolManagementBussinessLayer _schoolData;

        public TeacherController(ISchoolManagementBussinessLayer schoolData)
        {
            _schoolData = schoolData;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost("AddTeacher")]
        public IActionResult AddTeacher(Teacher teacher)
        {
            _schoolData.AddTeacher(teacher);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + teacher.TeacherId, teacher);
        }

        //Show all Teacher
        [HttpGet("ShowTeachers")]
        public IActionResult ShowTeachers() {

            return Ok(_schoolData.ShowTeachers());
        }

        //List of Teacher in Particular School
        [HttpGet("ShowTeachersInSchool")]
        public IActionResult ShowTeachersInSchool(int id) {

            return Ok(_schoolData.ShowTeachersInSchool(id));
        }


        [HttpGet]
        [Route("ShowTeacherRecord")]
        public IActionResult ShowTeacherRecord(int id) {

            var teacher = _schoolData.ShowTeacherRecord(id);

            if (teacher != null)
            {
                return Ok(teacher);
            }
            else
            {
                return NotFound($"School with Id : {id} was not found");
            }

        }

        [HttpDelete("DeleteTeacher/{id}")]
        public IActionResult DeleteTeacher(int id) {

            _schoolData.DeleteTeacher(id);

            return Ok(id);
        }
    }
}
