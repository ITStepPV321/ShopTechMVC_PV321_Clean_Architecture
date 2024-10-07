using BusinessLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Security;
using MimeKit.Text;
using MailKit.Net.Smtp;

using Org.BouncyCastle.Utilities;


namespace BusinessLogic.Sevices
{
    public class MailService : Interfaces.IMailService
    {
        private readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMailAsync(string subject, string body, string toSend, string? fromSend = null)
        {
            //SmtpClient smtpClient=new SmtpClient(); 
            //string EMAIL= "shrolts@gmail.com";
            // string emailFrom = _configuration["MailData:EmailFrom"];
           // var data = _configuration.GetSection("MailData").Get<MailData>();
           // string? EMAIL=data.EMAIL;

           string? EMAIL = _configuration["MailData:EmailFrom"];

           string? PASSWORD = _configuration["MailData:Password"];
           // string? PASSWORD = data.Password;

           string? HOST = _configuration["MailData:HOST"];
            //string? HOST = data.HOST;
            int PORT = int.Parse(_configuration["MailData:PORT"]);
            //int PORT = data.PORT;

            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(EMAIL));
            email.To.Add(MailboxAddress.Parse(toSend));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>Your order</h1><p>{body}</p>" };

            //smtpClient.Send(message);


            // send email
            using var smtp = new SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Connect(HOST, PORT, SecureSocketOptions.StartTls);
            smtp.Authenticate(EMAIL, PASSWORD);
            smtp.Send(email);
            smtp.Disconnect(true);

        }

    }

}
