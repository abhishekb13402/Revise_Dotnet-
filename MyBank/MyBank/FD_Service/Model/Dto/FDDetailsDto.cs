using System.ComponentModel.DataAnnotations;

namespace FD_Service.Model.Dto
{
    public class FDDetailsDto
    {
        public int Id { get; set; }
        public string FDPlan { get; set; }
        public double Year { get; set; }
        public double Percentage { get; set; }
    }
}
