using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CleanTestsApiExample.Room.Entity;
using CleanTestsApiExample.RoomReservation.Adapter.Primary;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event;
using CleanTestsApiExample.Tests.ComponentTests.Setup;
using Xunit;

namespace CleanTestsApiExample.Tests.ComponentTests.Tests
{
    public partial class When_making_a_reservation
    {
        public class Given_disabled_room : ApiTest
        {
            private HttpStatusCode _statusCode;

            public Given_disabled_room(ProgramWithFakes setup) : base(setup)
            {
                RoomRepository.DisableAllRooms();
            }

            protected override async Task Act()
            {
                _statusCode = await Put<HttpStatusCode>($"rooms/{Freeze<RoomNumber>()}/reservation", Freeze<ReservationRequestBody>());
            }

            [Fact]
            public void No_room_is_reserved() =>
                Assert.Empty(ReservationRepository.Reservations);

            [Fact]
            public void ReservationAttemptOnDisabledRoom_event_is_transmitted() =>
                Assert.IsType<ReservationAttemptOnDisabledRoom>(EventTransmitter.TransmittedEvents.Single());

            [Fact]
            public void Transmitted_event_is_for_correct_room() =>
                Assert.Equal(Frozen<RoomNumber>(), EventTransmitter.TransmittedEventOfType<ReservationAttemptOnDisabledRoom>().RoomNumber);


            [Fact]
            public void Status_code_423_is_returned() =>
                Assert.Equal(HttpStatusCode.Locked, _statusCode);
        }
    }
}