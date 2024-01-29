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
            try
            {
                var newSheduled = new Sheduled
                {

                    SheduledId = request.SheduledId,
                    CourseName = request.CourseName,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    Day = request.Day,
                    
                };
                var obj = appDBContext.Sheduled.Add(newSheduled);
                await appDBContext.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
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

        public IEnumerable<Sheduled> GetAllSheduled()
        {
            try
            {
                return appDBContext.Sheduled.ToList();
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
                    result.CourseName = sheduled.CourseName;
                    result.StartTime = sheduled.StartTime;
                    result.EndTime = sheduled.EndTime;
                    result.Day = sheduled.Day;
                   


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
