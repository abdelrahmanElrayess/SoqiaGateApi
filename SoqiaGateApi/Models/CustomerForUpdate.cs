using System.ComponentModel.DataAnnotations;

namespace SoqiaGateApi.Models
{
    public class CustomerForUpdate
    {
        [Required]
        [MaxLength(10)]
        public string? NationalId { get; set; }
        [Required]
        public int FamilySize { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? FatherName { get; set; }
        [Required]
        public string? GrandfatherName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? MobileNumber { get; set; }
        [Required]
        public string? POBox { get; set; }
        [Required]
        public string? PostalCode { get; set; }
    }
}
