using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event
{
    public class ReservationAttemptOnDisabledRoom : IEvent
    {
        public string EventType => typeof(ReservationAdded).FullName;

        public RoomNumber RoomNumber { get; }

        public ReservationAttemptOnDisabledRoom(RoomNumber roomNumber)
        {
            RoomNumber = roomNumber;
        }
    }
}