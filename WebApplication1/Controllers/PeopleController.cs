using Microsoft.AspNetCore.Mvc;
using WebApplication1.BusinessLogic.Services;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.Controllers
{
    
            [Route("api/[controller]")]
            [ApiController]
            public class PeopleController : ControllerBase
        {
            private readonly PeopleService _peopleService;
            public PeopleController(PeopleService people)
            {
                _peopleService = people;
            }

            [HttpGet]
            public ActionResult<IEnumerable<People>> GetAllUser()
            {
                var UserList = _peopleService.GetAllUser();

                if (UserList == null)
                {
                    return NotFound();
                }
                return Ok(UserList);
            }

            [HttpPost]
            public async Task<ActionResult<People>> CreateUser(People request)
            {
                return await _peopleService.CreateUser(request);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<People>> UpdateUser([FromRoute] int id, [FromBody] People people)
            {
                try
                {
                    if (id != people.UserId)
                    {
                        return BadRequest("User ID Mismatch");
                    }

                    var UserToUpdate = await _peopleService.GetUserById(id);

                    if (UserToUpdate == null)
                    {
                        return NotFound($"User with ID = {id} not found");
                    }

                    return await _peopleService.UpdateUser(people);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
    

