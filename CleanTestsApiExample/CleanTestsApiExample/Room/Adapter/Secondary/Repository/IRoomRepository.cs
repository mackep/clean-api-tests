using System.Threading.Tasks;
using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.Room.Adapter.Secondary.Repository
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Determines whether a room is enabled for reservations or not. VIP rooms
        /// and rooms undergoing renovation are not enabled.
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns>True if enabled, false if not enabled</returns>
        Task<bool> IsEnabled(RoomNumber roomNumber);
    }
}