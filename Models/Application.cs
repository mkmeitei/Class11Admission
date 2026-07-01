using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Class11Admission.Models
{
    public class Application
    {
        public int Id {get; set;}

        //Personal Info
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public String FullName {get; set;} = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth {get; set;}

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile number is required")]
        [Display(Name = "Mobile Number")]
        [Phone]
        public string MobileNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // --- Academic Info ---
        [Required(ErrorMessage = "Previous school name is required")]
        [Display(Name = "Previous School")]
        public string PreviousSchool { get; set; } = string.Empty;


        [Required(ErrorMessage = "Board is required")]
        [Display(Name = "Board (CBSE / ICSE / State)")]
        public string Board { get; set; } = string.Empty;

        [Required(ErrorMessage = "Percentage is required")]
        [Display(Name = "Class 10 Percentage")]
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100")]
        [Column(TypeName = "decimal(5,2)")]   // ← add this line
        public decimal Percentage { get; set; }

        // --- Stream Choice ---
        [Required(ErrorMessage = "Please select a stream")]
        [Display(Name = "Preferred Stream")]
        public string Stream { get; set; } = string.Empty;  
        // Science / Commerce / Arts

        // --- Status (set by Admin) ---
        [Display(Name = "Application Status")]
        public string Status { get; set; } = "Pending";
        // Pending / Shortlisted / Approved / Rejected

        [Display(Name = "Applied On")]
        public DateTime AppliedOn { get; set; } = DateTime.Now;

        // Unique token so student can check their status
        public string TrackingId { get; set; } = string.Empty;
    }
}