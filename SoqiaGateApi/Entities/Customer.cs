using SoqiaGateApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoqiaGateApi.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
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


        public virtual ICollection<CustomerHouse>? House { get; set; } 

        public virtual ICollection<WaterOrder>? WaterOrders { get; set; } 



    }
}
