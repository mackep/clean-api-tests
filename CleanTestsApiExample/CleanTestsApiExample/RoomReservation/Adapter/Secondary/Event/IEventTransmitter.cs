using System.Threading.Tasks;

namespace CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event
{
    public interface IEventTransmitter
    {
        public Task TransmitEvent(IEvent evnt);
    }
}
