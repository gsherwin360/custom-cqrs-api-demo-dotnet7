using System.ComponentModel.DataAnnotations;

namespace Customers.Api.Models;

public class CreateCustomerModel
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;
}
