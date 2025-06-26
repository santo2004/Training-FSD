using Microsoft.AspNetCore.Mvc;
using HotelService.Models;

namespace HotelService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private static List<Room> rooms = new List<Room>
        {
            new Room { Id = 1, HotelId = 1, RoomType = "Deluxe", Price = 3000 },
            new Room { Id = 2, HotelId = 1, RoomType = "Suite", Price = 5000 },
            new Room { Id = 3, HotelId = 2, RoomType = "Standard", Price = 2000 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetAllRooms()
        {
            return Ok(rooms);
        }

        [HttpGet("hotel/{hotelId}")]
        public ActionResult<IEnumerable<Room>> GetRoomsByHotel(int hotelId)
        {
            var filteredRooms = rooms.Where(r => r.HotelId == hotelId).ToList();
            return Ok(filteredRooms);
        }
    }
}
