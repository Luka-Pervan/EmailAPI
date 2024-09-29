using EmailAPI.Models;
using EmailAPI.Repositories.Interfaces;
using EmailServiceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailAPI.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailContext _context;

        public EmailRepository(EmailContext context)
        {
            _context = context;
        }

        public async Task AddEmailAsync(Email email)
        {
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Email>> GetEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }
    }
}
