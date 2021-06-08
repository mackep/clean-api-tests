using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CleanTestsApiExample.RoomReservation.DataObject
{
    public static class FailureResponse
    {
        public static IActionResult From(FailureReason? reason)
        {
            return reason switch
            {
                FailureReason.NotEnabledForReservation => new StatusCodeResult((int) HttpStatusCode.Locked),
                FailureReason.RoomAlreadyReserved => new StatusCodeResult((int) HttpStatusCode.Conflict),
                _ => throw new ArgumentOutOfRangeException(nameof(reason), reason, null)
            };
        }
    }
}