using Microsoft.AspNetCore.Mvc;
using BookingService.Models;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private static List<Booking> bookings = new List<Booking>
        {
            new Booking
            {
                Id = 1,
                UserId = 1,
                HotelId = 2,
                RoomId = 3,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(3)
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAllBookings()
        {
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult<Booking> CreateBooking(Booking newBooking)
        {
            newBooking.Id = bookings.Max(b => b.Id) + 1;
            bookings.Add(newBooking);
            return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.Id }, newBooking);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            bookings.Remove(booking);
            return NoContent();
        }
    }
}
