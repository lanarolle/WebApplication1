using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.BusinessLogic.Services
{
    public class StudentCoursesService
    {
        private readonly IStudentCoursesRepository _StudentCourses;

        public StudentCoursesService(IStudentCoursesRepository StudentCourses)
        {
            _StudentCourses = StudentCourses;
        }

        // create studetcourse

        public async Task<StudentCourses> CreateStudentCourses(StudentCourses Request)
        {
            try
            {
                return await _StudentCourses.CreateStudentCourses(Request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // get all studentcourses

        public IEnumerable<StudentCourses> GetAllStudentCourses()
        {

            try
            {
                return (IEnumerable<StudentCourses>)_StudentCourses.GetAllStudentCourses().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // get student

        public async Task<StudentCourses?> GetStudentCoursesById(int id)
        {
            try
            {
                return await _StudentCourses.GetStudentCoursesById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
