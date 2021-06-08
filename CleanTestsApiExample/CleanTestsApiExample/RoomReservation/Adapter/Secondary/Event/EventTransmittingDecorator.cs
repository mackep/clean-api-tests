using System.Threading.Tasks;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Repository;
using CleanTestsApiExample.RoomReservation.DataObject;
using CleanTestsApiExample.RoomReservation.Service;

namespace CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event
{
    public class EventTransmittingDecorator : IRoomReservationService
    {
        private readonly IRoomReservationService _inner;
        private readonly IEventTransmitter _eventTransmitter;

        public EventTransmittingDecorator(IRoomReservationService inner, IEventTransmitter eventTransmitter)
        {
            _inner = inner;
            _eventTransmitter = eventTransmitter;
        }

        public async Task<ReservationResult> Reserve(ReservationQuery reservationQuery)
        {
            var result = await _inner.Reserve(reservationQuery);
            
            if (result.FailureReason == FailureReason.NotEnabledForReservation)
                await _eventTransmitter.TransmitEvent(new ReservationAttemptOnDisabledRoom(reservationQuery.RoomNumber));

            if (!result.ReservationFailed)
                await _eventTransmitter.TransmitEvent(new ReservationAdded(reservationQuery.RoomNumber));

            return result;
        }
    }
}