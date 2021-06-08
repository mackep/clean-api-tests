using CleanTestsApiExample.Guest;
using CleanTestsApiExample.Guest.Validation;
using Microsoft.AspNetCore.Mvc;

namespace CleanTestsApiExample.RoomReservation.Adapter.Primary
{
    public class ReservationRequestBody
    {        
        [FromBody]
        [ValidGuestName]
        public string Name { get; set; }
    }
}