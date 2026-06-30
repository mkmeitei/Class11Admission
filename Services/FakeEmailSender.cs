using Microsoft.AspNetCore.Identity.UI.Services;

namespace Class11Admission.Services
{
    // Stub email sender — does nothing for now.
    // Real email sending (e.g. via SendGrid) can be added later.
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"[FakeEmailSender] To: {email} | Subject: {subject}");
            return Task.CompletedTask;
        }
    }
}