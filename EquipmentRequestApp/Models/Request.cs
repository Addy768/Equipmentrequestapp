using System.ComponentModel.DataAnnotations;

namespace EquipmentRequestApp.Models
{
    public class Request
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Phone number format should be xxx-xxx-xxxx")]
        public string Phone { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public EquipmentType Equipment { get; set; }

        [Required]
        public string RequestDetails { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0.")]
        public int Duration { get; set; }

        
        public RequestStatus Status { get; set; } = RequestStatus.Pending; 
    }

    
    public enum RequestStatus
    {
        Pending,    
        Accepted,   
        Denied      
    }
}
