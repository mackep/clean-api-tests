using System;
using System.Linq;

namespace CleanTestsApiExample.RoomReservation.Entity
{
    public readonly struct ReservationRef
    {
        private readonly string _reference;
        private static readonly string _expectedPrefix = "R";

        public ReservationRef(string reference)
        {
            bool IsValid(string r)
            {
                var prefix = r?.First().ToString();
                var sequenceNumber = r != null && r.Length > 1 ? r.Substring(1) : string.Empty;

                return prefix == _expectedPrefix && int.TryParse(sequenceNumber, out _);
            }

            if (!IsValid(reference))
                throw new ArgumentOutOfRangeException(nameof(reference), "Reference is not in valid format");

            _reference = reference;
        }

        public static implicit operator string(ReservationRef r) => r._reference;
        public static implicit operator ReservationRef(string s) => new(s);

        public override string ToString() => _reference;
    }
}
