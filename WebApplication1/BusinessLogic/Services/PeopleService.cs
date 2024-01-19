using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.BusinessLogic.Services
{
   
    public class PeopleService
    {
        private readonly IPeopleRepository _people;

        public PeopleService(IPeopleRepository people)
        {
            _people = people;
        }


        public async Task<People> CreateUser(People Request)
        {
            try
            {
                return await _people.CreateUser(Request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<People> GetAllUser()
        {

            try
            {
                return _people.GetAllUser().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<People?> GetUserById(int id)
        {
            try
            {
                return await _people.GetUserById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<People?> UpdateUser(People people)
        {
            try
            {
                return await _people.UpdateUser(people);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
