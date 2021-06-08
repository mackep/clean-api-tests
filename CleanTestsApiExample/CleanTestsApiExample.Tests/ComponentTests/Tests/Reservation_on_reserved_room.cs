using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CleanTestsApiExample.RoomReservation.Adapter.Primary;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event;
using CleanTestsApiExample.RoomReservation.Entity;
using CleanTestsApiExample.Tests.ComponentTests.Setup;
using Xunit;

namespace CleanTestsApiExample.Tests.ComponentTests.Tests
{
    public partial class When_making_a_reservation
    {
        public class Given_reserved_room : ApiTest
        {
            private HttpStatusCode _statusCode;

            public Given_reserved_room(ProgramWithFakes setup) : base(setup)
            {
                ReservationRepository.Reservations.Add(Freeze<Reservation>());
            }

            protected override async Task Act()
            {
                _statusCode = await Put<HttpStatusCode>($"rooms/{Frozen<Reservation>().RoomNumber}/reservation", Freeze<ReservationRequestBody>());
            }

            [Fact]
            public void Existing_reservation_is_not_modified() =>
                Assert.Equal(Frozen<Reservation>().Name, ReservationRepository.Reservation.Name);

            [Fact]
            public void No_events_are_sent() =>
                Assert.Empty(EventTransmitter.TransmittedEvents);

            [Fact]
            public void Status_code_409_is_returned() =>
                Assert.Equal(HttpStatusCode.Conflict, _statusCode);
        }
    }
}