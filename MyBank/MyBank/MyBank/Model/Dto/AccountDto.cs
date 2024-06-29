using System.ComponentModel.DataAnnotations;

namespace MyBank.Model.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public AccountType accounttype { get; set; }
        public double Balance { get; set; }
        //public PersonDto Person { get; set; }
        //public string OTPValue { get; set; }
        //public DateTime ExpiryTime { get; set; }
        //public bool IsUsed { get; set; } = false;
    }
}
