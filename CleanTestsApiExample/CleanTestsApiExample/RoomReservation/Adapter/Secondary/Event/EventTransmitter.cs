using System.Threading.Tasks;

namespace CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event
{
    public class EventTransmitter : IEventTransmitter
    {
        public Task TransmitEvent(IEvent evnt)
        {
            /*
             * In a real world scenario, this method would probably
             * transmit the event to an event bus or similar. For this
             * example application, this class is a simple fake and does
             * therefore not transmit the event anywhere.
             */

            return Task.CompletedTask;
        }
    }
}