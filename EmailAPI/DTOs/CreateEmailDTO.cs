using EmailAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailAPI.DTOs
{
    public class CreateEmailDTO
    {
        [Required]
        [EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        [EmailAddress]
        public string ToEmail { get; set; }

        public string CcEmails { get; set; } // comma-separated CC emails

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        public int Importance { get; set; } = (int)EmailImportance.Normal;
    }
}
