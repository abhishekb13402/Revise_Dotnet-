using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MyBank_MVC_Project.Common.Mail
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _settings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_settings.Email, _settings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendBirthdayEmailAsync(string toEmail, string firstName)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = toEmail;
            mailRequest.Subject = $"Happy Birthday {firstName}.";
            mailRequest.Body = $"Happy Birthday {firstName}.";
            await SendEmailAsync(mailRequest);
        }

        public async Task<bool> SendDepositEmailAsync(string? toEmail, double amount, int id)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = toEmail;
            mailRequest.Subject = "Deposit Confirmation";
            mailRequest.Body = $"In your Account Deposit amount : {amount} has been successfully made to your account with ID: {id}.";
            await SendEmailAsync(mailRequest);
            return true;
        }
        public async Task<bool> SendWithdrawEmailAsync(string? fromEmail, double amount, int id)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = fromEmail;
            mailRequest.Subject = "Withdrawal Confirmation";
            mailRequest.Body = $"In your Account Withdraw amount : {amount} has been successfully made to your account with ID: {id}.";
            await SendEmailAsync(mailRequest);
            return true;
        }

        public async Task<bool> SendFundTransferEmailAsync(string? toEmail, string? fromEmail, double amount, int id)
        {
            SendDepositEmailAsync(toEmail, amount, id);
            SendWithdrawEmailAsync(fromEmail, amount, id);
            return true;
        }

        public async Task<bool> SendGenerateOtpEmailAsync(string otp, string Email, DateTime ExpiryTime)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = Email;
            mailRequest.Subject = "OTP Confirmation";
            mailRequest.Body = $"OTP is: {otp} \n \n Valid till : {ExpiryTime}";
            await SendEmailAsync(mailRequest);
            return true;
        }


    }
}
