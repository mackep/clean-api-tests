using System.Threading.Tasks;
using CleanTestsApiExample.Room.Validation;
using CleanTestsApiExample.RoomReservation.DataObject;
using CleanTestsApiExample.RoomReservation.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTestsApiExample.RoomReservation.Adapter.Primary
{
    [Authorize]
    [Route("rooms")]
    [ApiController]
    public class RoomReservationController : Controller
    {
        private readonly IRoomReservationService _service;

        public RoomReservationController(IRoomReservationService service)
        {
            _service = service;
        }

        [HttpPut]
        [Route("{roomNumber}/reservation")]
        public async Task<IActionResult> Add(
            [FromRoute][ValidRoomNumber] int roomNumber,
            [FromBody] ReservationRequestBody body)
        {
            var result = await _service.Reserve(new ReservationQuery(roomNumber, body.Name));

            return result.ReservationFailed
                ? FailureResponse.From(result.FailureReason)
                : SuccessResponse.From(result.Reservation);
        }
    }
}