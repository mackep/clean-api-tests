using System;
using AutoFixture;
using CleanTestsApiExample.RoomReservation.Entity;
using CleanTestsApiExample.Tests.ComponentTests.Fakes;
using CleanTestsApiExample.Tests.ComponentTests.Setup.AutoFixture.SpecimenBuilders;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup.AutoFixture
{
    public static class AutoFixtureSetup
    {
        public static Fixture WithCustomizations(this Fixture fixture)
        {
            fixture.Customizations.Add(new RoomNumberBuilder());
            fixture.Customizations.Add(new ReservationRefBuilder());

            return fixture;
        }

        public static Fixture AppliedOn(this Fixture fixture, IServiceProvider services)
        {
            services.GetRequiredService<FakeReservationRepository>().ReferenceGenerator =
                fixture.Create<ReservationRef>;

            return fixture;
        }
    }
}
