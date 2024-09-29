using EmailAPI.Models;

namespace EmailAPI.Repositories.Interfaces
{
    public interface IEmailRepository
    {
        Task AddEmailAsync(Email email);
        Task<List<Email>> GetEmailsAsync();
    }
}
