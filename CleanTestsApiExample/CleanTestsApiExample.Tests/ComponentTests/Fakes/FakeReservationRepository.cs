using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Repository;
using CleanTestsApiExample.RoomReservation.DataObject;
using CleanTestsApiExample.RoomReservation.Entity;

namespace CleanTestsApiExample.Tests.ComponentTests.Fakes
{
    public class FakeReservationRepository : IReservationRepository
    {
        public List<Reservation> Reservations = new();

        public IEnumerable<ReservationRef> References => Reservations.Select(v => v.Reference);

        public Reservation Reservation => Reservations.Single();

        public Func<ReservationRef> ReferenceGenerator { get; set; }

        public async Task<string> TryReserve(ReservationQuery reservationQuery)
        {
            await Task.CompletedTask;

            if (ReferenceGenerator == null)
                throw new Exception("Unable to make reservation - no reference generator has been provided");

            if (Reservations.Any(r => r.RoomNumber == reservationQuery.RoomNumber))
                return null;

            Reservations.Add(
                new Reservation(
                    ReferenceGenerator.Invoke(),
                    reservationQuery.RoomNumber,
                    reservationQuery.Name));

            return Reservations.Last().Reference;
        }

        public void ClearAllReservations()
        {
            Reservations.Clear();
        }
    }
}
