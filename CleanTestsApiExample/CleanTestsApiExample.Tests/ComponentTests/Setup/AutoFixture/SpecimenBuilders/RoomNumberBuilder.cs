using System;
using System.Linq;
using AutoFixture;
using AutoFixture.Kernel;
using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup.AutoFixture.SpecimenBuilders
{
    public class RoomNumberBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!(request is SeededRequest sr))
            {
                return new NoSpecimen();
            }
            if ((Type) sr.Request != typeof(RoomNumber))
            {
                return new NoSpecimen();
            }

            return (RoomNumber) context.Create<Generator<int>>()
                .First(n => n >= RoomNumber.Min && n <= RoomNumber.Max);
        }
    }
}