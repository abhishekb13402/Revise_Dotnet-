using AutoMapper.Internal;

namespace MyBank_MVC_Project.Common.Mail
{
    public interface IMailService
    {
        Task<bool> SendGenerateOtpEmailAsync(string otp, string Email, DateTime ExpiryTime);
        Task SendBirthdayEmailAsync(string toEmail, string firstName);
        Task<bool> SendDepositEmailAsync(string? toEmail, double amount, int id);
        Task<bool> SendWithdrawEmailAsync(string? fromEmail, double amount, int id);
        Task<bool> SendFundTransferEmailAsync(string? toEmail, string? fromEmail, double amount, int id);
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
