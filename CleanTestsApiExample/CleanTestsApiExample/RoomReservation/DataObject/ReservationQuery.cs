using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.RoomReservation.DataObject
{
    public class ReservationQuery
    {
        public ReservationQuery(RoomNumber roomNumber, string name)
        {
            RoomNumber = roomNumber;
            Name = name;
        }

        public RoomNumber RoomNumber { get; }
        public string Name { get; }
    }
}