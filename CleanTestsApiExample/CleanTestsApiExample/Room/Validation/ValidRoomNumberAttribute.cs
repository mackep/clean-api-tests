using System.ComponentModel.DataAnnotations;
using CleanTestsApiExample.Room.Entity;

namespace CleanTestsApiExample.Room.Validation
{
    public class ValidRoomNumberAttribute : ValidationAttribute
    {
        public static int Min = 100;
        public static int Max = 999;

        public override bool IsValid(object value)
        {
            return value is int numericValue && numericValue >= RoomNumber.Min && numericValue <= RoomNumber.Max;
        }
    }
}