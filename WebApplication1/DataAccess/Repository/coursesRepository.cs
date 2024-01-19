using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;
using courses = WebApplication1.DataAccess.Models.courses;
//using courses = WebApplication1.Migrations.courses;

namespace WebApplication1.DataAccess.Repository
{
    public class coursesRepository : IcoursesRepository
    {
        ApplicationDBContext appDBContext;

        public coursesRepository(ApplicationDBContext context)
        {
            appDBContext = context;
        }

        internal static List<courses> GetCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<courses> Createcourses(courses request)
        {
            try
            {
                var newcourses = new courses { CourseId = request.CourseId, CourseName = request.CourseName, CourseDescription = request.CourseDescription, CourseCredit = request.CourseCredit, };
                var obj = appDBContext.courses.Add(newcourses);
                await appDBContext.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Deletecourses(int courseId)
        {
            try
            {
                var obj = await appDBContext.courses.FirstOrDefaultAsync(e => e.CourseId ==   courseId  );
                if (obj != null)
                {
                    appDBContext.courses.Remove(obj);
                    await appDBContext.SaveChangesAsync();
                    return obj.CourseId;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<courses> GetAllcourses()
        {
            try
            {
                return appDBContext.courses.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<courses> GetcourseById(int id)
        {
            try
            {
                return await appDBContext.courses.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<courses> Updatecourses(courses courses)
        {
            try
            {
                var result = await appDBContext.courses.FirstOrDefaultAsync(e => e.CourseId == courses.CourseId);
                if (result != null)
                {

                    /*CourseId = request.CourseId,
                    CourseName = request.CourseName,
                    CourseDescription = request.CourseDescription,
                    CourseCredit = request.CourseCredit,*/
                    


                    result.CourseId = courses.CourseId;
                    result.CourseName = courses.CourseName;
                    result.CourseDescription = courses.CourseDescription;   
                    result.CourseCredit = courses.CourseCredit;
                    


                    await appDBContext.SaveChangesAsync();
                    return result;

                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        Task<Models.courses> IcoursesRepository.Createcourses(Models.courses request)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Models.courses> IcoursesRepository.GetAllcourses()
        {
            throw new NotImplementedException();
        }

        async Task<Models.courses> IcoursesRepository.GetcoursesById(int id)
        {
            try
            {
                return await appDBContext.courses.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        Task<Models.courses> IcoursesRepository.Updatecourses(Models.courses courses)
        {
            throw new NotImplementedException();
        }
    }
}

