using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillReimbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyBill : ControllerBase
    {
        private readonly IApplyBillService _service;
        public ApplyBill(IApplyBillService service)
        {
            _service = service;
        }
        // GET: api/<ApllyBill>
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IEnumerable<ViewApplyBillModelService> Get()
        {
            return _service.GetAll();
        }

        // GET api/<ApllyBill>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public IEnumerable<ViewApplyBillModelService> Get(string id)
        {
            try
            {
                return _service.GetByIdAll(id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ViewApplyBillModelService>();
            }
            
        }

        // POST api/<ApllyBill>
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Post(ApplyBillModelService bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Add(bill);
                    return Ok();
                }
                else return BadRequest();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ApllyBill>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public IActionResult Put(ApplyBillModelService bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.update(bill);
                    return Ok(bill);
                }
                else
                {
                    return BadRequest();
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ApllyBill>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

       
    }
}
