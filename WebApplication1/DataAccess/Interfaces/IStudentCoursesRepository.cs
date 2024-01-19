using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IStudentCoursesRepository
    {


        public Task<StudentCourses> CreateStudentCourses(StudentCourses request);

        public IEnumerable<StudentCourses> GetAllStudentCourses();

        public Task<StudentCourses> GetStudentCoursesById(int id);

    }
}
