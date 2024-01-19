using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IStudentRepository
    {

        public Task<Student> CreateStudent(Student request);


        public IEnumerable<Student> GetAllStudents();

        public Task<Student> GetStudentById(int id);

        public Task<Student> UpdateStudent(Student student);

        
        public Task<int> DeleteStudent(int StudentId);


    }
}
