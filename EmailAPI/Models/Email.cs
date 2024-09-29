using System.ComponentModel.DataAnnotations;

namespace EmailAPI.Models
{
    public class Email
    {
        #region Constructors
        public Email()
        {
                
        }
        #endregion

        #region Properties

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        [EmailAddress]
        public string ToEmail { get; set; }

        public string CcEmails { get; set; }  // comma-separated CC emails

        public string Subject { get; set; }

        [Required]
        public EmailImportance Importance { get; set; } = EmailImportance.Normal;

        [Required]
        public string Content { get; set; }

        public DateTime DateSent { get; set; } = DateTime.UtcNow;

        #endregion
    }
    public enum EmailImportance
    {
        Low = 1,
        Normal,
        High
    }
}
