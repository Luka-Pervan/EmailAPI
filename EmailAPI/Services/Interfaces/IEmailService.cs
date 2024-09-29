using EmailAPI.DTOs;
using EmailAPI.Models;

namespace EmailAPI.Services.Interfaces
{
    public interface IEmailService
    {
        Task<EmailResponseDTO> SendEmailAsync(CreateEmailDTO email);
        Task<List<EmailResponseDTO>> GetEmailHistoryAsync();
    }
}
