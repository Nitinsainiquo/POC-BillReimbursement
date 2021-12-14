using BillReimbursement.Repository.Models;
using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using BillReimbursement.Service.Services;
using BillReimbursement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillReimbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public Employee(IEmployeeService employeeService)
        {
            _employeeService = employeeService; 
        }
        // GET: api/<Employee>
        [HttpGet]
        [Authorize]
        public IEnumerable<EmployeeModelService> Get()
        {
            return _employeeService.GetAll();
        }

        // GET api/<Employee>/5
        [HttpGet("{id}")]
        public EmployeeModelService Get(string id)
        {
            return _employeeService.GetById(id);
        }

        // POST api/<Employee>
        [HttpPost]
        public IActionResult Post(EmployeeModelService emp)
        {
            emp.Password = CommonMethods.ConvertToEncrypt(emp.Password);
            try
            {
                _employeeService.Add(emp);
                return Ok(new {code = 200});
            }
            catch (Exception ex)
            {
                return BadRequest(new { error =  "Email Id already exist" });
            }
            
        }

        // PUT api/<Employee>/5
        [HttpPut("{id}")]
        public IActionResult Put(EmployeeModelService emp)
        {
            _employeeService.update(emp);
            return Ok(emp);
        }

        // DELETE api/<Employee>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.Delete(id);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel emp)
        {
            EmployeeModelService employee = _employeeService.GetById(emp.EmailId);
            if(employee!= null&& CommonMethods.ConvertToDecrypt(employee.Password) == emp.Password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("EmailId", employee.EmailId.ToString()),
                        new Claim(ClaimTypes.Role, employee.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")),SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenhandler = new JwtSecurityTokenHandler();
                var securtiyToken = tokenhandler.CreateToken(tokenDescriptor);
                var token = tokenhandler.WriteToken(securtiyToken);
                return Ok(new {token = token});
            }
            else
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }
            

        }

    }
}
