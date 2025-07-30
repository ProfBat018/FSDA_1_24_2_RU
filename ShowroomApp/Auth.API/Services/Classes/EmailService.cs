using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Auth.API.Services.Classes;

public class EmailService 
{
    private IConfiguration _configuration;
    private readonly SmtpClient _client;
    
    // переменная, которая хранит в себе данные окружения, в том числе и папки. 

    
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        _client = new()
        {
            Host = _configuration["Email:Host"],
            Port = 587,
            EnableSsl = true
        };
        _client.Credentials = new NetworkCredential()
        {
            UserName = _configuration["Email:Username"],
            Password = _configuration["Email:Password"]
        };
    }

    public async Task SendEmailAsync(string email, string username, string subject, string content)
    {
        var message = new MailMessage()
        {
            From = new MailAddress(_configuration["Email:From"]),
            Subject = subject,
            Body = content,
            IsBodyHtml = true
        };

        message.To.Add(new MailAddress(email));

        await _client.SendMailAsync(message);
    }
}