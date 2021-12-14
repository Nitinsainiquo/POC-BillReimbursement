using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillReimbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public UserProfileController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Authorize]
        public async Task<object> GetUserProfile()
        {
            string UserId = User.Claims.First(c=>c.Type =="EmailId").Value;
            EmployeeModelService emp = _employeeService.GetById(UserId);
            return new UserprofileModel
            {
               FullName = emp.FullName,
               EmailId = emp.EmailId,
               Role = emp.Role,
            };
        }

    }
}
