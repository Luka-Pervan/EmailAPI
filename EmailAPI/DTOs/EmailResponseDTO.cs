namespace EmailAPI.DTOs
{
    public class EmailResponseDTO
    {
        public int Id { get; set; }

        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public string CcEmails { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public string Importance { get; set; } // Show it as a string for better readability

        public DateTime DateSent { get; set; }
    }
}
