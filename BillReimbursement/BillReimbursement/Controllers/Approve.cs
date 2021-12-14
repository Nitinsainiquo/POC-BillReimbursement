using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillReimbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Approve : ControllerBase
    {
        private readonly IApplyBillService _service;
        public Approve(IApplyBillService service)
        {
            _service = service;
        }
        // PUT api/<Approve>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(ApplyBillModelService bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.updateApproved(bill);
                    return Ok(bill);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
