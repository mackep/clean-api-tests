using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.RoomReservation.Entity
{
    public class Reservation
    {
        public ReservationRef Reference { get; }
        public RoomNumber RoomNumber { get; }
        public string Name { get; }

        public Reservation(ReservationRef reference, RoomNumber roomNumber, string name)
        {
            Reference = reference;
            RoomNumber = roomNumber;
            Name = name;
        }
    }
}