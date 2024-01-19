using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApplication1.BusinessLogic.Services;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService student)
        {

            _studentService = student;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var studentList = _studentService.GetAllStudents();

            if (studentList == null)
            {
                return NotFound();
            }
            return Ok(studentList);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student request)
        {
            Console.WriteLine(request);
            return await _studentService.CreateStudent(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteStudent(int id)
        {
            try
            {
                var result = await _studentService.DeleteStudent(id);

                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }
       
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent([FromRoute] int id, [FromBody] Student student)
        {
            try
            {
                if (id != student.StuRegId)
                {
                    return BadRequest("Student ID Mismatch");
                }

                var studentToUpdate = await _studentService.GetStudentById(id);

                if (studentToUpdate == null )
                {
                    return NotFound($"Student with ID = {id} not found");
                }

                return await _studentService.UpdateStudent(student);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }     
}
