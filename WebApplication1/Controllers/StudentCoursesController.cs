using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApplication1.BusinessLogic.Services;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentCoursesController : ControllerBase
    {
        private readonly StudentCoursesService _StudentCoursesService;
        public StudentCoursesController(StudentCoursesService StudentCourses)
        {

            _StudentCoursesService = StudentCourses;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<StudentCourses>> GetAllStudentCourses()
        {
            var StudentCoursesList = _StudentCoursesService.GetAllStudentCourses();

            if (StudentCoursesList == null)
            {
                return NotFound();
            }
            return Ok(StudentCoursesList);
        }

        [HttpPost]
        public async Task<ActionResult<StudentCourses>> CreateStudentCourses(StudentCourses request)
        {
            return await _StudentCoursesService.CreateStudentCourses(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCourses>> GetStudentCoursesById(int id)
        {
            var StudentCourses = await _StudentCoursesService.GetStudentCoursesById(id);

            if (StudentCourses == null)
            {
                return NotFound();
            }

            return StudentCourses;
        }

    }
}
