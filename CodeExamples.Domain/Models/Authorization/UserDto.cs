using System.ComponentModel.DataAnnotations;

namespace CodeExamples.Domain.Models.Authorization;

public class UserDto
{
    [Required(ErrorMessage = "Email required")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Booking Reference required")]
    public string BookingRef { get; set; } = string.Empty;
}