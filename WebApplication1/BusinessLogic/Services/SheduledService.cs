using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.BusinessLogic.Services
{

    public class SheduledService
    {
        private readonly ISheduledRepository _sheduled;

        public SheduledService(ISheduledRepository Sheduled)
        {
            _sheduled = Sheduled;
        }


        public async Task<Sheduled> CreateSheduled(Sheduled Request)
        {
            try
            {
                return await _sheduled.CreateSheduled(Request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Sheduled> GetAllSheduled()
        {
            try
            {
                return _sheduled.GetAllSheduled().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteSheduled(String SheduledId)
        {
            try
            {
                return await _sheduled.DeleteSheduled(SheduledId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sheduled?> UpdateSheduled(Sheduled sheduled)
        {
            try
            {
                return await _sheduled.UpdateSheduled(sheduled);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
