using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
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
                var newcourses = new courses { CourseName = request.CourseName, CourseDescription = request.CourseDescription, CourseCredit = request.CourseCredit, };
                var obj = appDBContext.courses.Add(newcourses);
                await appDBContext.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                //throw;

                
                throw;
            }
        }

        public async Task<string> Deletecourses(string courseName)
        {
            try
            {
                var obj = await appDBContext.courses.FirstOrDefaultAsync(e => e.CourseName ==   courseName  );
                if (obj != null)
                {
                    appDBContext.courses.Remove(obj);
                    await appDBContext.SaveChangesAsync();
                    return obj.CourseName;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //public async Task(courses) Deletecourses(string CourseName)
        //{

        //}

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

        /*public async Task<courses> Updatecourses(courses courses)
        {
            try
            {
                var result = await appDBContext.courses.FirstOrDefaultAsync(e => e.CourseName == courses.CourseName);
                if (result != null)
                {

                    /*CourseId = request.CourseId,
                    CourseName = request.CourseName,
                    CourseDescription = request.CourseDescription,
                    CourseCredit = request.CourseCredit,*/
                    


                  
                   /* result.CourseName = courses.CourseName;
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
        }*/

        async Task<Models.courses> IcoursesRepository.Createcourses(Models.courses request)
        {
            try
            {
                var newcourses = new courses {
                    
                    CourseName = request.CourseName,
                    CourseDescription = request.CourseDescription,
                    CourseCredit = request.CourseCredit,
                
                
                };
                var obj = appDBContext.courses.Add(newcourses);
                await appDBContext.SaveChangesAsync();
                return obj.Entity;
            }

            catch (Exception)
            {
                throw;
            }
        }

        //Task<courses> IcoursesRepository.Deletecourses(string CourseName)
        //{
        //    throw new NotImplementedException();
        //}

        IEnumerable<Models.courses> IcoursesRepository.GetAllcourses()
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

       /* Task<Models.courses> IcoursesRepository.Updatecourses(Models.courses courses)
        {
            throw new NotImplementedException();
        }*/

        public async Task<courses> UpdateCourses(courses courses)
        {
            string courseName = courses.CourseName;
            var courseFromDatabase = await appDBContext.courses.FirstOrDefaultAsync(u => u.CourseName == courseName);
            if (courseFromDatabase != null)
            {
                courses Courses = new courses
                {
                    CourseName = courses.CourseName,
                    CourseDescription= courses.CourseDescription,
                    CourseCredit= courses.CourseCredit,
                };

                appDBContext.Entry(courseFromDatabase).CurrentValues.SetValues(courses);

                await appDBContext.SaveChangesAsync();

                return courseFromDatabase;
            }

            return null;
        }
    }
}

