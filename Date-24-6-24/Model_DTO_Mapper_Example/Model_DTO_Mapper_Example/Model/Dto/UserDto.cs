using System.ComponentModel.DataAnnotations;

namespace Model_DTO_Mapper_Example.Model.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public DateOnly DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
