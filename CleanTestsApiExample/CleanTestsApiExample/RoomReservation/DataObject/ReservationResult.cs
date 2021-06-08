using CleanTestsApiExample.RoomReservation.Entity;

namespace CleanTestsApiExample.RoomReservation.DataObject
{
    public class ReservationResult
    {
        public Reservation Reservation { get; }
        public FailureReason? FailureReason { get; }

        public bool ReservationFailed => FailureReason != null;

        private ReservationResult(Reservation reservation, FailureReason? failureReason = null)
        {
            Reservation = reservation;
            FailureReason = failureReason;
        }

        public static ReservationResult Success(Reservation reservation)
        {
            return new(reservation);
        }

        public static ReservationResult Failure(FailureReason failureReason)
        {
            return new(null, failureReason);
        }
    }
}