using System.Threading.Tasks;
using CleanTestsApiExample.Room.Adapter.Secondary.Repository;
using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.Tests.ComponentTests.Fakes
{
    public class FakeRoomRepository : IRoomRepository
    {
        public bool RoomIsEnabled { get; set; } = true;

        public Task<bool> IsEnabled(RoomNumber roomNumber)
        {
            return Task.FromResult(RoomIsEnabled);
        }

        public void EnableAllRooms()
        {
            RoomIsEnabled = true;
        }

        public void DisableAllRooms()
        {
            RoomIsEnabled = false;
        }
    }
}