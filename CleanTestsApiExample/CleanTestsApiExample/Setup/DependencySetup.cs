using CleanTestsApiExample.Room.Adapter.Secondary.Repository;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Event;
using CleanTestsApiExample.RoomReservation.Adapter.Secondary.Repository;
using CleanTestsApiExample.RoomReservation.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTestsApiExample.Setup
{
    public static class DependencySetup
    {
        public static void AddPrimaryAdapters(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<RoomReservationService>();
            services.AddSingleton<IRoomReservationService>(s =>
                new EventTransmittingDecorator(
                    s.GetService<RoomReservationService>(),
                    s.GetService<IEventTransmitter>()));
        }

        public static void AddSecondaryAdapters(this IServiceCollection services, IConfiguration config)
        {
            services.AddRoomRepository(config);
            services.AddReservationRepository(config);
            services.AddEventTransmitter(config);
        }

        private static void AddRoomRepository(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IRoomRepository, RoomRepository>();
            services.Configure<RoomRepositoryConfig>(
                config.GetSection("RoomRepository"));
        }

        private static void AddReservationRepository(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IReservationRepository, ReservationRepository>();
            services.Configure<ReservationRepositoryConfig>(
                config.GetSection("ReservationRepository"));
        }

        private static void AddEventTransmitter(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IEventTransmitter, EventTransmitter>();
            services.Configure<ReservationRepositoryConfig>(
                config.GetSection("EventBus"));
        }
    }
}