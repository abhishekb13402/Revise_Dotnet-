using System.ComponentModel.DataAnnotations;

namespace MyBank_MVC_Project.Models.Account
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Phone]
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<MyTransactions> Transaction { get; set; }

    }
}
