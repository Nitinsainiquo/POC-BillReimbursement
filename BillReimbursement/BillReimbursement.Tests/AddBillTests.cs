using BillReimbursement.Controllers;
using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BillReimbursement.Tests
{
    public class AddBillTests
    {
        private readonly ApplyBill applyBill;
        private readonly Mock<IApplyBillService> _applyBillMock = new Mock<IApplyBillService>();

        public AddBillTests()
        {
            applyBill = new ApplyBill(_applyBillMock.Object);
        }

        [Fact]
        public void Get_Returns_The_Correct_Number_Of_Bills()
        {
            List<ViewApplyBillModelService> _billList = new List<ViewApplyBillModelService>()
            {
                new ViewApplyBillModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                },
                new ViewApplyBillModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                },
                new ViewApplyBillModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                }
            };
            _applyBillMock.Setup(x => x.GetAll()).Returns(_billList);
            IEnumerable<ViewApplyBillModelService> _bill = applyBill.Get();
            Assert.Equal(3, _bill.Count<ViewApplyBillModelService>());
        }

        [Fact]
        public void GetById_Returns_The_Correct_Number_Of_Bills_With_Same_Id()
        {
            List<ViewApplyBillModelService> _billList = new List<ViewApplyBillModelService>()
            {
                new ViewApplyBillModelService()
                {
                    EmailId = "test@test.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                },
                new ViewApplyBillModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                },
                new ViewApplyBillModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                }
            };
            _applyBillMock.Setup(x => x.GetByIdAll("test@test.com")).Returns(_billList);
            IEnumerable<ViewApplyBillModelService> _bill = applyBill.Get("test@test.com");
            Assert.Equal(3, _bill.Count<ViewApplyBillModelService>());
        }

        [Fact]
        public void GetById_Returns_The_bill_With_Same_Id()
        {
            List<ViewApplyBillModelService> _billList = new List<ViewApplyBillModelService>()
            {
                new ViewApplyBillModelService()
                {
                    EmailId = "test@test.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                },
                new ViewApplyBillModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                },
                new ViewApplyBillModelService()
                {
                    EmailId = "test1@gmail.com",
                    FullName = "test1",
                    PaymentMode = "bank",
                    Status = "pending",
                    ApplyDate = DateTime.Now,
                    Amount  = 4000,
                    Id =    47,
                    ModifiedBy = "Nitin",
                    Remarks = "Good",
                    Type = "Food",
                }
            };
            _applyBillMock.Setup(x => x.GetByIdAll("test@test.com")).Returns(_billList);
            IEnumerable<ViewApplyBillModelService> _bill = applyBill.Get("test@test.com");
            Assert.Equal("test@test.com", _bill.ElementAt(0).EmailId);
        }
        [Fact]
        public void GetById_Returns_EmptyList_When_NoItemFound()
        {
            List<ViewApplyBillModelService> _billList = new List<ViewApplyBillModelService>()
            {
                
            };
            _applyBillMock.Setup(x => x.GetByIdAll("test@test.com")).Returns(()=>null);
            IEnumerable<ViewApplyBillModelService> _bill = applyBill.Get("test@test.com");
            Assert.Null(_bill);
        }

        [Fact]
        public void Post_bill_return_Ok_Status()
        {
            var billone = new ApplyBillModelService()
            {
                EmailId = "test@test.com",
                PaymentMode = "bank",
                Status = "pending",
                ApplyDate = DateTime.Now,
                Amount = 4000,
                Id = 47,
                ModifiedBy = "Nitin",
                Remarks = "Good",
                Type = "Food",
            };
            _applyBillMock.Setup(x => x.Add(billone));
            var _bill = applyBill.Post(billone);
            Assert.IsType<OkResult>(_bill);
           
        }

        [Fact]
        public void Put_bill_return_Ok_Status()
        {
            var billone = new ApplyBillModelService()
            {
                EmailId = "test@test.com",
                PaymentMode = "bank",
                Status = "pending",
                ApplyDate = DateTime.Now,
                Amount = 4000,
                Id = 47,
                ModifiedBy = "Nitin",
                Remarks = "Good",
                Type = "Food",
            };
            _applyBillMock.Setup(x => x.update(billone));
            var _bill = applyBill.Put(billone);
            Assert.IsType<OkObjectResult>(_bill);

        }

        [Fact]
        public void Delete_bill_return_Ok_Status()
        {
            var billone = new ApplyBillModelService()
            {
                EmailId = "test@test.com",
                PaymentMode = "bank",
                Status = "pending",
                ApplyDate = DateTime.Now,
                Amount = 4000,
                Id = 47,
                ModifiedBy = "Nitin",
                Remarks = "Good",
                Type = "Food",
            };
            _applyBillMock.Setup(x => x.Delete(5));
            var _bill = applyBill.Delete(5);
            Assert.IsType<OkResult>(_bill);

        }
    }
}
