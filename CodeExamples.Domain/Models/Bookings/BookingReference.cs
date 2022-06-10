namespace CodeExamples.Domain.Models.Bookings;

public class BookingReference
{
    public string RedirectUrl { get; private init; } = string.Empty;

    public string Account { get; private init; } = string.Empty;

    public bool HasBooking { get; private init; }

    public static BookingReference NotFound()
    {
        return new BookingReference
        {
            HasBooking = false
        };
    }

    public static BookingReference FirstBooking()
    {
        return new BookingReference
        {
            HasBooking = true,
            RedirectUrl = "first.com",
            Account = "FIRST"
        };
    }

    public static BookingReference SecondBooking()
    {
        return new BookingReference
        {
            HasBooking = true,
            RedirectUrl = "second.com",
            Account = "SECOND"
        };
    }
}