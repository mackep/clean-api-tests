using System.Threading.Tasks;
using CleanTestsApiExample.RoomReservation.DataObject;

namespace CleanTestsApiExample.RoomReservation.Service
{
    public interface IRoomReservationService
    {
        Task<ReservationResult> Reserve(ReservationQuery reservationQuery);
    }
}