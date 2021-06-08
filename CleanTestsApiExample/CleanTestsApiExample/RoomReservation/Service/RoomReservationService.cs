using System;
using System.Threading.Tasks;
using CleanTestsApiExample.Room.Adapter.Secondary.Repository;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Repository;
using CleanTestsApiExample.RoomReservation.DataObject;
using CleanTestsApiExample.RoomReservation.Entity;

namespace CleanTestsApiExample.RoomReservation.Service
{
    public class RoomReservationService : IRoomReservationService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public RoomReservationService(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationResult> Reserve(ReservationQuery reservationQuery)
        {
            if (reservationQuery == null)
                throw new ArgumentNullException(nameof(reservationQuery));

            var enabled = await _roomRepository.IsEnabled(reservationQuery.RoomNumber);
            if (!enabled)
                return ReservationResult.Failure(FailureReason.NotEnabledForReservation);

            var reference = await _reservationRepository.TryReserve(reservationQuery);
            if (reference == null)
                return ReservationResult.Failure(FailureReason.RoomAlreadyReserved);

            return ReservationResult.Success(
                new Reservation(reference,
                    reservationQuery.RoomNumber,
                    reservationQuery.Name));
        }
    }
}