using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApplication1.BusinessLogic.Services;
using WebApplication1.DataAccess.Models;
using WebApplication1.DataAccess.Repository;

namespace WebApplication1.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class CoursesController : ControllerBase
        {
            private readonly coursesService _coursesService;
            public CoursesController(coursesService courses)
            {

                _coursesService = courses;

            }

            /*[HttpGet]
            public ActionResult<IEnumerable<courses>> GetAllcourses()
            {
                var coursesList = _coursesService.GetAllcourses();

                if (coursesList == null)
                {
                    return NotFound();
                }
                return Ok(coursesList);
            }*/

            [HttpGet]
            [Route("courses")]
            
            public List<courses> GetAllcourses()
            {
                List<courses> courses = coursesRepository.GetCourses();
                return courses;
            }

            [HttpPost]
            public async Task<ActionResult<courses>> Createcourses(courses request)
            {
                return await _coursesService.Createcourses(request);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<courses>> GetcoursesById(int id)
            {
                var courses = await _coursesService.GetcoursesById(id);

                if (courses == null)
                {
                    return NotFound();
                }

                return courses;

            }

        }
    
    
}
