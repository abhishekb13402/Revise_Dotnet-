using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FD_Service.Model.Dto
{
    public class CustomerFDDetailsDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public string Plan { get; set; }
        public DateOnly StartDate { get; set; }
    }
}
