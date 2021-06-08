using System.Threading.Tasks;
using CleanTestsApiExample.RoomReservation.DataObject;

namespace CleanTestsApiExample.RoomReservation.Adapter.Secondary.Repository
{
    public interface IReservationRepository
    {
        /// <summary>
        /// Allows a room to be reserved.
        /// </summary>
        /// <param name="reservationQuery"></param>
        /// <returns>Reservation reference if reservation is successful, otherwise null</returns>
        Task<string> TryReserve(ReservationQuery reservationQuery);
    }
}