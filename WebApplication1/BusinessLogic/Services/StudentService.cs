using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.BusinessLogic.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _student;

        public StudentService(IStudentRepository student)
        {
            _student = student;
        }

        // create studet

        public async Task<Student> CreateStudent(Student Request)
        {
            try
            {
                return await _student.CreateStudent(Request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // get all student

        public IEnumerable<Student> GetAllStudents()
        {

            try
            {
                return _student.GetAllStudents().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // get student

        public async Task<Student?> GetStudentById(int id)
        {
            try
            {
                return await _student.GetStudentById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // delete student

        public async Task<int> DeleteStudent(int studentID)
        {
            try
            {
                return await _student.DeleteStudent(studentID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update student
        public async Task<Student?> UpdateStudent(Student student)
        {
            try
            {
                return await _student.UpdateStudent(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Task<ActionResult<StudentCourses>> CreateStudentCourses(StudentCourses request)
        {
            throw new NotImplementedException();
        }

        internal Task GetStudentCoursesById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
