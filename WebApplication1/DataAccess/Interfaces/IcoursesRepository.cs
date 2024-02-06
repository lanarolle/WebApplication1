using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IcoursesRepository
    {
        public Task<courses> Createcourses(courses request); 


        public IEnumerable<courses> GetAllcourses();

        public Task<courses> GetcoursesById(int id);

        public Task<courses> Updatecourses(courses courses);

        public Task<string> Deletecourses(string CourseName);

    }
}
