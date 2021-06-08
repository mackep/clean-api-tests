using System.Threading.Tasks;
using CleanTestsApiExample.Room.Entity;
using Microsoft.Extensions.Options;

namespace CleanTestsApiExample.Room.Adapter.Secondary.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IOptions<RoomRepositoryConfig> _config;

        public RoomRepository(IOptions<RoomRepositoryConfig> config)
        {
            _config = config;
        }

        public Task<bool> IsEnabled(RoomNumber roomNumber)
        {
            /*
             * In a real world scenario, the repository config would
             * probably be used in some kind of way when communicating
             * with the underlying database. The repository in this
             * example is a simple fake and is therefore not dependent
             * on any configuration.
             */

            return Task.FromResult(true);
        }
    }
}