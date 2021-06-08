using System;
using System.Net;
using AutoFixture;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CleanTestsApiExample.Tests.ComponentTests.Fakes;
using CleanTestsApiExample.Tests.ComponentTests.Setup.Auth;
using CleanTestsApiExample.Tests.ComponentTests.Setup.AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup
{
    public abstract class ApiTest : IClassFixture<ProgramWithFakes>, IAsyncLifetime
    {
        private readonly HttpClient _client;
        private readonly IServiceProvider _services;
        private readonly IFixture _fixture;

        protected ApiTest(ProgramWithFakes setup)
        {
            _services = setup.Services;
            _client = setup.CreateClient();
            _fixture = new Fixture().WithCustomizations().AppliedOn(_services);
        }

        protected FakeAuthConfiguration AuthConfig => _services.GetService<FakeAuthConfiguration>();
        protected FakeReservationRepository ReservationRepository => _services.GetService<FakeReservationRepository>();
        protected FakeRoomRepository RoomRepository => _services.GetService<FakeRoomRepository>();
        protected FakeEventTransmitter EventTransmitter => _services.GetService<FakeEventTransmitter>();

        public async Task<TResponse> Put<TResponse>(string url, object body)
        {
            var response = await _client.PutAsync(url,
                new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json"));

            if (typeof(TResponse) == typeof(HttpStatusCode))
                return (TResponse) (object) response.StatusCode;

            if (!response.IsSuccessStatusCode)
                return default;

            var responseJson = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(responseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        protected T Freeze<T>() => _fixture.Freeze<T>();

        protected T Frozen<T>() => Freeze<T>();

        protected abstract Task Act();

        protected virtual void CleanUp()
        {
            ReservationRepository.ClearAllReservations();
            EventTransmitter.TransmittedEvents.Clear();
        }

        public async Task InitializeAsync()
        {
            await Act();
        }

        public Task DisposeAsync()
        {
            CleanUp();

            return Task.CompletedTask;
        }
    }
}