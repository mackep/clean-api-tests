using CleanTestsApiExample.Room.Adapter.Secondary.Repository;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Repository;
using CleanTestsApiExample.Tests.ComponentTests.Fakes;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup.Dependencies
{
    public static class DependencySetup
    {
        public static IServiceCollection AddFakeSecondaryAdapters(this IServiceCollection services)
        {
            services.AddSingleton<FakeReservationRepository>();
            services.AddSingleton<IReservationRepository, FakeReservationRepository>(s => s.GetService<FakeReservationRepository>());

            services.AddSingleton<FakeRoomRepository>();
            services.AddSingleton<IRoomRepository, FakeRoomRepository>(s => s.GetService<FakeRoomRepository>());

            services.AddSingleton<FakeEventTransmitter>();
            services.AddSingleton<IEventTransmitter, FakeEventTransmitter>(s => s.GetService<FakeEventTransmitter>());

            return services;
        }
    }
}