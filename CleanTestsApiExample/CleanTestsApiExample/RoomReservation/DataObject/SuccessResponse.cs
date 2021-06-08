using CleanTestsApiExample.RoomReservation.Adapter.Primary;
using CleanTestsApiExample.RoomReservation.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CleanTestsApiExample.RoomReservation.DataObject
{
    public static class SuccessResponse
    {
        public static IActionResult From(Reservation reservation)
        {
            return new OkObjectResult(new ReservationResponse
            {
                Reference = reservation.Reference,
                RoomNumber = reservation.RoomNumber,
                Name = reservation.Name
            });
        }
    }
}