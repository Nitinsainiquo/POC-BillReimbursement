using BillReimbursement.Controllers;
using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BillReimbursement.Tests
{
    public class EmployeeControllerTests
    {
        private readonly Employee emp;
        private readonly Mock<IEmployeeService> _employeeMock = new Mock<IEmployeeService>();

        public EmployeeControllerTests()
        {
            emp = new Employee(_employeeMock.Object);
        }

        [Fact]
        public void Get_Returns_The_Correct_Employee()
        {
            var empDto = new EmployeeModelService
            {
                EmailId = "test1@gmail.com",
                FullName = "test1",
                Password = "jkashdkasjdkjask",
                Role = "User"
            };
            var empId = "test1@gmail.com";
            _employeeMock.Setup(x => x.GetById(empId)).Returns(empDto);
            
            EmployeeModelService _employee = emp.Get(empId);

            Assert.Equal(empId, _employee.EmailId);
        }

        [Fact]
        public void Get_Returns_Null_When_No_Data_Found()
        {
            var empId = "test@gmail.com";
            _employeeMock.Setup(x => x.GetById(empId)).Returns(()=>null);

            EmployeeModelService _employee = emp.Get(empId);

            Assert.Null(_employee);
        }

        [Fact]
        public void Post_user_Return_200_Ok_status()
        {
            var empDto = new EmployeeModelService
            {
                EmailId = "test1@gmail.com",
                FullName = "test1",
                Password = "jkashdkasjdkjask",
                Role = "User"
            };

            var _employee = emp.Post(empDto);

            Assert.IsType<OkObjectResult>(_employee);
        }

        [Fact]
        public void Get_Returns_The_Correct_Number_Of_Employees()
        {
            List<EmployeeModelService> _empList =  new List<EmployeeModelService>()
            {
                new EmployeeModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    Password = "jkashdkasjdkjask",
                    Role = "User"
                },
                new EmployeeModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    Password = "jkashdkasjdkjask",
                    Role = "User"
                },
                new EmployeeModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    Password = "jkashdkasjdkjask",
                    Role = "User"
                }
            };
                
            
            _employeeMock.Setup(x => x.GetAll()).Returns(_empList);

            IEnumerable<EmployeeModelService> _employee = emp.Get();

            Assert.Equal(3, _employee.Count<EmployeeModelService>());
        }

        [Fact]
        public void Delete_Returns_The_Remaining_Number_Of_Employees()
        {
            List<EmployeeModelService> _empList = new List<EmployeeModelService>()
            {
                new EmployeeModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    Password = "jkashdkasjdkjask",
                    Role = "User"
                },
                new EmployeeModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    Password = "jkashdkasjdkjask",
                    Role = "User"
                },
                new EmployeeModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    Password = "jkashdkasjdkjask",
                    Role = "User"
                }
            };


            _employeeMock.Setup(x => x.Delete(5));
            _employeeMock.Setup(x => x.GetAll()).Returns(_empList);
            IEnumerable<EmployeeModelService> _employee = emp.Get();

            Assert.Equal(3, _employee.Count<EmployeeModelService>());
        }

        [Fact]
        public void Put_user_Return_200_Ok_status()
        {
            var empDto = new EmployeeModelService
            {
                EmailId = "test1@gmail.com",
                FullName = "test1",
                Password = "jkashdkasjdkjask",
                Role = "User"
            };

            var _employee = emp.Put(empDto);

            Assert.IsType<OkObjectResult>(_employee);
        }


    }
}