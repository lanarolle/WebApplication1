using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;


namespace WebApplication1.DataAccess.Repository
{
    public class StudentCoursesRepository : IStudentCoursesRepository
    {
        ApplicationDBContext appDBContext;

        public StudentCoursesRepository(ApplicationDBContext context)
        {
            appDBContext = context;
        }

        internal static List<StudentCoursesRepository> GetStudentCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentCourses> CreateStudentCourses(StudentCourses request)
        {
            try
            {
                var newStudentCourses = new StudentCourses { StudentCoursesId = request.StudentCoursesId, StuRegId = request.StuRegId, CourseId = request.CourseId, };
                var obj = appDBContext.StudentCourses.Add(newStudentCourses);
                await appDBContext.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IEnumerable<StudentCourses> GetAllStudentCourses()
        {
            try
            {
                return appDBContext.StudentCourses.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<StudentCourses> GetStudentCoursesById(int id)
        {
            try
            {
                return await appDBContext.StudentCourses.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        Task<Models.StudentCourses> IStudentCoursesRepository.CreateStudentCourses(Models.StudentCourses request)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Models.StudentCourses> IStudentCoursesRepository.GetAllStudentCourses()
        {
            throw new NotImplementedException();
        }

        async Task<Models.StudentCourses> IStudentCoursesRepository.GetStudentCoursesById(int id)
        {
            try
            {
                return await appDBContext.StudentCourses.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}