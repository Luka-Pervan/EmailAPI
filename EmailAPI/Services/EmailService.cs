using AutoMapper;
using EmailAPI.DTOs;
using EmailAPI.Models;
using EmailAPI.Repositories.Interfaces;
using EmailAPI.Services.Interfaces;
using EmailServiceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public EmailService(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public async Task<EmailResponseDTO> SendEmailAsync(CreateEmailDTO createEmailDto)
        {
            // Email Validation
            if (string.IsNullOrEmpty(createEmailDto.FromEmail) || !IsValidEmail(createEmailDto.FromEmail))
                throw new ArgumentException("Invalid From Email address");

            if (string.IsNullOrEmpty(createEmailDto.ToEmail) || !IsValidEmail(createEmailDto.ToEmail))
                throw new ArgumentException("Invalid To Email address");

            // Map DTO to Email entity using AutoMapper
            var email = _mapper.Map<Email>(createEmailDto);

            email.DateSent = DateTime.UtcNow; // Automatically set the DateSent field

            // Save the email using the repository
            await _emailRepository.AddEmailAsync(email);

            // Map the Email entity back to EmailResponseDTO and return it
            return _mapper.Map<EmailResponseDTO>(email);
        }

        public async Task<List<EmailResponseDTO>> GetEmailHistoryAsync()
        {
            // Retrieve emails from the repository
            var emails = await _emailRepository.GetEmailsAsync();

            // Map the list of Email entities to a list of EmailResponseDTOs
            return _mapper.Map<List<EmailResponseDTO>>(emails);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
