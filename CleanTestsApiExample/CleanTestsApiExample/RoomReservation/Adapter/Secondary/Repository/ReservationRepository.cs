using System.Threading.Tasks;
using CleanTestsApiExample.RoomReservation.DataObject;
using Microsoft.Extensions.Options;

namespace CleanTestsApiExample.RoomReservation.Adapter.Secondary.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IOptions<ReservationRepositoryConfig> _config;

        public ReservationRepository(IOptions<ReservationRepositoryConfig> config)
        {
            _config = config;
        }

        public Task<string> TryReserve(ReservationQuery reservationQuery)
        {
            /*
             * In a real world scenario, the repository config would
             * probably be used in some kind of way when communicating
             * with the underlying database. The repository in this
             * example is a simple fake and is therefore not dependent
             * on any configuration.
             */

            return Task.FromResult("Successfully reserved!");
        }
    }
}
