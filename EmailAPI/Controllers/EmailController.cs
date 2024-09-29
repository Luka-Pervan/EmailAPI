using EmailAPI.DTOs;
using EmailAPI.Models;
using EmailAPI.Services.Interfaces;
using EmailServiceAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // POST: api/email/send
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] CreateEmailDTO emailDto)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Call the service to send the email and get the response DTO
                var emailResponse = await _emailService.SendEmailAsync(emailDto);
                return Ok(new { message = "Email stored successfully", email = emailResponse });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/email/history
        [HttpGet("history")]
        public async Task<IActionResult> GetEmailHistory()
        {
            try
            {
                // Call the service to get the email history
                var emailHistory = await _emailService.GetEmailHistoryAsync();
                return Ok(emailHistory);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
