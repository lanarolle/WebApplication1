using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Repository
{
    public class SheduledRepository : ISheduledRepository
    {
        ApplicationDBContext appDBContext;

        public SheduledRepository(ApplicationDBContext context)
        {
            appDBContext = context;
        }

        public async Task<Sheduled> CreateSheduled(Sheduled request)
        {
            var existingCourse = appDBContext.courses.FirstOrDefault( c => c.CourseName == request.CourseName);
            try
            {
                var newSheduled = new Sheduled
                {
                    
                   SheduledId = request.SheduledId,
                   CourseName = request.CourseName,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    Day = request.Day,
                   // CourseSchedules= new List<CourseSchedules>(),
                  //  Coursecode=request.Coursecode,
                    
                };

            


               // var obj = appDBContext.Sheduled.Add(newSheduled);
                await appDBContext.Sheduled.AddAsync(newSheduled);
                await appDBContext.SaveChangesAsync();

                CourseSchedules courseSchedules = new CourseSchedules
                {
                    SheduledId = newSheduled.SheduledId,
                    CourseName = request.CourseName,
                };
                appDBContext.CourseSchedules.Add(courseSchedules);
      
                await appDBContext.SaveChangesAsync();
                return newSheduled;// obj.Entity;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<int> DeleteSheduled(int SheduledId)
        {
            try
            {
                var obj = await appDBContext.Sheduled.FirstOrDefaultAsync(e => e.SheduledId == SheduledId);
                if (obj != null)
                {
                    appDBContext.Sheduled.Remove(obj);
                    await appDBContext.SaveChangesAsync();
                    return obj.SheduledId;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }


            

        }

        public Task<string> DeleteSheduled(string SheduledId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sheduled>> GetAllSheduled()
        {
            try
            {
                // return appDBContext.Sheduled.ToList();
                return await appDBContext.Sheduled.ToListAsync();
                
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Sheduled> UpdateSheduled(Sheduled sheduled)
        {
            try
            {
                var result = await appDBContext.Sheduled.FirstOrDefaultAsync(e => e.SheduledId == sheduled.SheduledId);

                if (result != null)
                {

                    //result.Name = student.StuRegId;
                    //result.Address = student.Address;
                    // result.Email = student.Email;
                    // result.Mobile = student.Mobile;
                    //result.Password = student.Password;


                    result.SheduledId = sheduled.SheduledId;
                    //result.course = sheduled.course;
                    result.StartTime = sheduled.StartTime;
                    result.EndTime = sheduled.EndTime;
                    result.Day = sheduled.Day;
                    result.CourseName = sheduled.CourseName;


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

    }
}
