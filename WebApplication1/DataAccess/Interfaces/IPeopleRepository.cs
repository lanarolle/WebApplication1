using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IPeopleRepository
    {
        public Task<People> CreateUser(People request);


        public IEnumerable<People> GetAllUser();

        public Task<People?> GetUserById(int id);

        // public IEnumerable<User> GetUserByEmail(string email);

        public Task<People> UpdateUser(People User);
    }
}
