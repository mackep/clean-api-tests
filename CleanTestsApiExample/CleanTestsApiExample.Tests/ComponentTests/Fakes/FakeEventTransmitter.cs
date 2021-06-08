using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event;

namespace CleanTestsApiExample.Tests.ComponentTests.Fakes
{
    public class FakeEventTransmitter : IEventTransmitter
    {
        public List<IEvent> TransmittedEvents = new();

        public Task TransmitEvent(IEvent evnt)
        {
            TransmittedEvents.Add(evnt);

            return Task.CompletedTask;
        }

        public T TransmittedEventOfType<T>() where T : IEvent
        {
            return (T)TransmittedEvents.Single();
        }
    }
}
