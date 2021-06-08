using System;
using AutoFixture;
using AutoFixture.Kernel;
using CleanTestsApiExample.RoomReservation.Entity;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup.AutoFixture.SpecimenBuilders
{
    public class ReservationRefBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!(request is SeededRequest sr))
            {
                return new NoSpecimen();
            }
            if ((Type)sr.Request != typeof(ReservationRef))
            {
                return new NoSpecimen();
            }

            return (ReservationRef) $"R{context.Create<int>()}";
        }
    }
}