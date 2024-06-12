using System.Net;
using System.Net.Mail;

namespace Common.Application.Services.Email
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            if (Environment.GetEnvironmentVariable("SEND_EMAIL") == "false")
                return;

            var mail = "suportehelpdesksenai@gmail.com";
            var pw = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            string htmlMessage = $@"
            <html>
            <head>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f0f0f0;
                        color: #333;
                        margin: 0;
                        padding: 0;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: 20px auto;
                        padding: 20px;
                        background-color: #fff;
                        border-radius: 8px;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }}
                    h1 {{
                        color: #4E6AFF;
                    }}
                    p {{
                        margin-bottom: 20px;
                    }}
                    .btn {{
                        display: inline-block;
                        background-color: #4E6AFF;
                        color: #fff;
                        padding: 10px 20px;
                        text-decoration: none;
                        border-radius: 5px;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>{subject}</h1>
                    {message}
                    <p>Atenciosamente,<br>Equipe HelpDesk</p>
                </div>
            </body>
            </html>";

            var mailMessage = new MailMessage(from: mail, to: email)
            {
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            await client.SendMailAsync(mailMessage);
        }
    }
}
