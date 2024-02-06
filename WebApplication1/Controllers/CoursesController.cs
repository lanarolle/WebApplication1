using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using WebApplication1.BusinessLogic.Services;
using WebApplication1.DataAccess;
using WebApplication1.DataAccess.Models;
using WebApplication1.DataAccess.Repository;

namespace WebApplication1.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class CoursesController : ControllerBase
        {
            private readonly coursesService _coursesService;
            private readonly ApplicationDBContext applicationDBContext;
        private readonly coursesRepository coursesRepository;

        public CoursesController(coursesService courses,ApplicationDBContext applicationDBContext)
            {

                _coursesService = courses;
             this.applicationDBContext = applicationDBContext;
          //  this.coursesRepository = coursesRepository;
        }

            [HttpGet]
            public ActionResult<IEnumerable<courses>> GetAllcourses()
            {
                var coursesList = _coursesService.GetAllcourses();

                if (coursesList == null)
                {
                    return NotFound();
                }
                return Ok(coursesList);
            }

            //[HttpGet]
            //[Route("courses")]
            
            //public List<courses> GetAllcourses()
            //{
            //    List<courses> courses = coursesRepository.GetCourses();
            //    return courses;
            //}

            [HttpPost]
            public async Task<ActionResult<courses>> Createcourses(courses request)
            {
            if (applicationDBContext.courses.Where(s => s.CourseName == request.CourseName).FirstOrDefault() != null)
            {
                return Ok("exists");
            }
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

            [HttpDelete("{courseName}")]
            public async Task<string> Deletecourses(string courseName)
            {
            string courses = await _coursesService.Deletecourses(courseName);
            return courses;
            }

        

        }
    
    
}
