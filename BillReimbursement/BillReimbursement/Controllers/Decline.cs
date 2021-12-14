using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillReimbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Decline : ControllerBase
    {
        private readonly IApplyBillService _service;
        public Decline(IApplyBillService service)
        {
            _service = service;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(ApplyBillModelService bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.updateDeclined(bill);
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
