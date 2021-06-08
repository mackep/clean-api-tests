using System;

namespace CleanTestsApiExample.Room.Entity
{
    public readonly struct RoomNumber
    {
        public static int Min = 100;
        public static int Max = 300;

        private readonly int _number;

        public RoomNumber(int number)
        {
            if (number < Min || number > Max)
                throw new ArgumentOutOfRangeException(nameof(number), $"Room number must be between {Min} and {Max} (inclusive).");

            _number = number;
        }

        public static implicit operator int(RoomNumber r) => r._number;
        public static implicit operator RoomNumber(int n) => new(n);

        public override string ToString() => $"{_number}";
    }
}