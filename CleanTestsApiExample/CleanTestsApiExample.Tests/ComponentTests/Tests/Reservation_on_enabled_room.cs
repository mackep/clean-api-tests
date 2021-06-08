using System.Linq;
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
        public class Given_enabled_available_room : ApiTest
        {
            private ReservationResponse _response;

            public Given_enabled_available_room(ProgramWithFakes setup) : base(setup)
            {
                RoomRepository.EnableAllRooms();
                ReservationRepository.ClearAllReservations();
            }

            protected override async Task Act()
            {
                _response = await Put<ReservationResponse>($"rooms/{Freeze<RoomNumber>()}/reservation", Freeze<ReservationRequestBody>());
            }

            [Fact]
            public void Room_is_reserved() =>
                Assert.Equal(Frozen<RoomNumber>(), ReservationRepository.Reservation.RoomNumber);

            [Fact]
            public void Room_is_reserved_using_name_from_request_body() =>
                Assert.Equal(Frozen<ReservationRequestBody>().Name, ReservationRepository.Reservation.Name);

            [Fact]
            public void RoomReservationEvent_is_transmitted() =>
                Assert.IsType<ReservationAdded>(EventTransmitter.TransmittedEvents.Single());

            [Fact]
            public void Transmitted_RoomReservationEvent_is_for_correct_room() =>
                Assert.Equal(Frozen<RoomNumber>(), EventTransmitter.TransmittedEventOfType<ReservationAdded>().RoomNumber);

            [Fact]
            public void Reference_is_returned_in_response() =>
                Assert.Equal(ReservationRepository.References.Single(), _response.Reference);
        }
    }
}