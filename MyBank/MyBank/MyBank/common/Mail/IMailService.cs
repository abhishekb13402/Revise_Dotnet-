﻿using AutoMapper.Internal;

namespace MyBank.common.Mail
{
    public interface IMailService
    {
        Task<bool> SendDepositEmailAsync(string? toEmail, double amount, int id);
        Task<bool> SendWithdrawEmailAsync(string? fromEmail, double amount, int id);
        Task<bool> SendFundTransferEmailAsync(string? toEmail, string? fromEmail, double amount, int id);
        Task SendEmailAsync(MailRequest mailRequest);

    }
}