using System.Net;
using System.Threading.Tasks;
using CleanTestsApiExample.Room.Entity;
using CleanTestsApiExample.RoomReservation.Adapter.Primary;
using CleanTestsApiExample.Tests.ComponentTests.Setup;
using Xunit;

namespace CleanTestsApiExample.Tests.ComponentTests.Tests
{
    public partial class When_making_a_reservation
    {
        public class Given_no_authentication : ApiTest
        {
            private HttpStatusCode _statusCode;

            public Given_no_authentication(ProgramWithFakes setup) : base(setup)
            {
                AuthConfig.InjectFakeAuthenticatedUser = false;
            }

            protected override async Task Act()
            {
                _statusCode = await Put<HttpStatusCode>($"rooms/{Freeze<RoomNumber>()}/reservation", Freeze<ReservationRequestBody>());
            }

            [Fact]
            public void Status_code_401_is_returned() =>
                Assert.Equal(HttpStatusCode.Unauthorized, _statusCode);
        }
    }
}
