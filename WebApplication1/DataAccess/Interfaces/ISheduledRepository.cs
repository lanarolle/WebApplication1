using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface ISheduledRepository
    {

        public Task<Sheduled> CreateSheduled(Sheduled request);


        public IEnumerable<Sheduled> GetAllSheduled();

       

        public Task<Sheduled> UpdateSheduled(Sheduled sheduled);


        public Task<string> DeleteSheduled(string SheduledId);
        Task<int> DeleteSheduled(int sheduledId);
    }
}
