using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess.Repository
{
    public class PeopleRepository : IPeopleRepository
    {



        ApplicationDBContext appDBContext;

        public PeopleRepository(ApplicationDBContext context)

        {

            appDBContext = context;

        }


        public async Task<People> CreateUser(People request)

        {

            try

            {

                var newUser = new People

                {



                    UserId = request.UserId,

                    StuEmail = request.StuEmail,

                    Password = request.Password,

                };

                var obj = appDBContext.People.Add(newUser);

                await appDBContext.SaveChangesAsync();

                return obj.Entity;

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

                return appDBContext.People.ToList();

            }

            catch (Exception)

            {

                throw;

            }

        }

        public Task<People?> GetUserById(int id)

        {

            throw new NotImplementedException();

        }

        public async Task<People> UpdateUser(People people)

        {

            try

            {

                var result = await appDBContext.People.FirstOrDefaultAsync(e => e.UserId == people.UserId);

                if (result != null)

                {

                    //result.Name = student.StuRegId;

                    //result.Address = student.Address;

                    // result.Email = student.Email;

                    // result.Mobile = student.Mobile;

                    //result.Password = student.Password;


                    result.UserId = people.UserId;

                    result.StuEmail = people.StuEmail;

                    result.Password = people.Password;



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

