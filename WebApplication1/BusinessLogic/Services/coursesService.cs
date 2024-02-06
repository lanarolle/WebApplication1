using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.BusinessLogic.Services
{
    //public class coursesService
    //{
    //internal object GetAllcourses()
    //{
    //    throw new NotImplementedException();
    //}


    //}

    public class coursesService
    {
        private readonly IcoursesRepository _courses;

        public coursesService(IcoursesRepository courses)
        {
            _courses = courses;
        }

        // create courses

        public async Task<courses> Createcourses(courses Request)
        {
            try
            {
                return await _courses.Createcourses(Request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // get all courses

        public IEnumerable<courses> GetAllcourses()
        {

            try
            {
                return _courses.GetAllcourses().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string?> Deletecourses(string CourseName)
        {
            try
            {
                return await _courses.Deletecourses(CourseName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // get courses

        public async Task<courses?> GetcoursesById(int id)
        {
            try
            {
                return await _courses.GetcoursesById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // delete student

       /* public async Task<int> DeleteStudent(int studentID)
        {
            try
            {
                return await _student.DeleteStudent(studentID);
            }
            catch (Exception)
            {
                throw;
            }
        }*/

        //update courses
        public async Task<courses?> Updatecourses(courses courses)
        {
            try
            {
                return await _courses.Updatecourses(courses);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}



