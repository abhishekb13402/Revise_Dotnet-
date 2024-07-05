using MyBank_MVC_Project.Models.Account;

namespace MyBank_MVC_Project.Models.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public AccountType accounttype { get; set; }
        public double Balance { get; set; }
    }
}
