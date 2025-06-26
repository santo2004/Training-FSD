using Microsoft.AspNetCore.Mvc;
using HotelService.Models;

namespace HotelService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Grand Palace", Location = "Chennai" },
            new Hotel { Id = 2, Name = "Sea View Inn", Location = "Goa" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetAllHotels()
        {
            return Ok(hotels);
        }
    }
}
