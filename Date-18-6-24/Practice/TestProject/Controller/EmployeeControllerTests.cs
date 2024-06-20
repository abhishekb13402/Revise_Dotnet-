using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using Practice.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Practice.Model.Dto;
using Practice.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controller
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;

        public EmployeeControllerTests()
        {
            _mockRepo = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public void AddEmployee_Success()
        {
            // Arrange
            SeedEmpData();

            var expectedResult = new EmployeeDto
            {
                Id = 1,
                Name = "wwww",
                EmployeeEmail = "string",
                Details = new EmployeeDetailsDto
                {
                    Id = 1,
                    DOB = DateTime.Parse("2024-06-17T11:16:35.444Z"),
                    Email = "string",
                    Phone = "string"
                }
            };

            var result = _mockRepo.Setup(repo => repo.AddEmployee(It.IsAny<EmployeeDto>()))
                     .ReturnsAsync(expectedResult);
            Assert.NotNull(result);
        }

        private static EmployeeDto SeedEmpData()
        {
            return new EmployeeDto
            {
                Id = 0,
                Name = "wwww",
                EmployeeEmail = "string",
                Details = new EmployeeDetailsDto
                {
                    Id = 0,
                    DOB = DateTime.Parse("2024-06-17T11:16:35.444Z"),
                    Email = "string",
                    Phone = "string"
                }
            };
        }
    }
}
