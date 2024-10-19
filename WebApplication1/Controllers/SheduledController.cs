using Microsoft.AspNetCore.Mvc;
using WebApplication1.BusinessLogic.Services;
using WebApplication1.DataAccess;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheduledController : ControllerBase
    {


        private readonly SheduledService _SheduledService;
        private readonly ApplicationDBContext applicationDBContext;



        public SheduledController(SheduledService sheduled, ApplicationDBContext applicationDBContext)
        {
            _SheduledService = sheduled;
            this.applicationDBContext = applicationDBContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Sheduled>> GetAllSheduled()
        {
            var sheduledList = _SheduledService.GetAllSheduled();

            if (sheduledList == null)
            {
                return NotFound();
            }
            return Ok(sheduledList.Result);
        }

        [HttpPost]
        public async Task<ActionResult<Sheduled>> CreateSheduled(Sheduled request)
        {
            return await _SheduledService.CreateSheduled(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteSheduled(int id)
        {
            try
            {
                var result = await _SheduledService.DeleteSheduled(id);

                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }




        // public IActionResult Index()
        // {
        //     return View();
        // }
    }
}
