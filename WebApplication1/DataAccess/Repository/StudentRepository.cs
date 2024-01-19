using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDBContext appDBContext;

        public StudentRepository(ApplicationDBContext context)
        {
            appDBContext= context;
        }

        public async Task<Student> CreateStudent(Student request)
        {
            try
            {
                var newStudent =new Student
                {

                    StuRegId = request.StuRegId,
                    StuName = request.StuName,
                    StuEmail = request.StuEmail,
                    StuMobNum = request.StuMobNum,
                    DOB = request.DOB,
                    StuAddress = request.StuAddress,
                    Password = request.Password,
                };
                var obj = appDBContext.Students.Add(newStudent);
                await appDBContext.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<int> DeleteStudent(int StudentId)
        {
            try
            {
                var obj = await appDBContext.Students.FirstOrDefaultAsync(e => e.StuRegId == StudentId);
                if(obj != null)
                {
                    appDBContext.Students.Remove(obj);
                    await appDBContext.SaveChangesAsync();
                    return obj.StuRegId;
                }
                return 0;
            }
            catch(Exception )
            {
                throw;
            }
           
        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return appDBContext.Students.ToList();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                return await appDBContext.Students.FindAsync(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
           try
            {
                var result = await appDBContext.Students.FirstOrDefaultAsync(e =>e.StuRegId == student.StuRegId);

                if(result != null)
                {

                    //result.Name = student.StuRegId;
                    //result.Address = student.Address;
                   // result.Email = student.Email;
                   // result.Mobile = student.Mobile;
                    //result.Password = student.Password;


                    result.StuRegId = student.StuRegId;
                    result.StuName = student.StuName;
                    result.StuEmail = student.StuEmail;
                    result.StuMobNum = student.StuMobNum;
                    result.DOB = student.DOB;
                    result.StuAddress = student.StuAddress;
                    result.Password = student.Password;


                    await appDBContext.SaveChangesAsync();
                    return result;

                }
                return null;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
