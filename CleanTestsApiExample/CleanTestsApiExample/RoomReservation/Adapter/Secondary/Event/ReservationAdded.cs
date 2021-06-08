using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event
{
    public class ReservationAdded : IEvent
    {
        public string EventType => typeof(ReservationAdded).FullName;

        public RoomNumber RoomNumber { get; }

        public ReservationAdded(RoomNumber roomNumber)
        {
            RoomNumber = roomNumber;
        }
    }
}