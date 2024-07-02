using AutoMapper.Internal;
using System.Threading.Tasks;

namespace MyBank.common.Mail
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
