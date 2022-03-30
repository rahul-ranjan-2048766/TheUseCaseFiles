using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pays_Transaction.Services;
using Pays_Transaction.Models;

namespace Pays_Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDetailController : ControllerBase
    {
        private readonly ITransactionDetailService service;
        public TransactionDetailController(ITransactionDetailService transactionDetailService)
        {
            service = transactionDetailService;
        }

        [HttpPost("AddDetail")]
        public IActionResult AddDetail(TransactionDetail detail)
        {
            try
            {
                detail.Date = DateTime.Now;
                service.AddDetail(detail);
                return Ok(new { message = "The transaction details are saved in the database successfully." });
            }
            catch
            {
                return BadRequest(new { message = "The system has thrown an exception. It is advised not to define the property Id of the JSON body." });
            }
        }

        [HttpDelete("DeleteDetail/{id}")]
        public IActionResult DeleteDetail(int id)
        {
            try
            {
                service.DeleteDetail(id);
                return Ok(new { message = "The transaction detail is successfully deleted from the database." });
            }
            catch
            {
                return BadRequest(new { message = "The transaction detail having id " + id + " does not exist in the database." });
            }
        }

        [HttpGet("GetTransactionDetailById/{id}")]
        public IActionResult GetTransactionDetailById(int id)
        {
            try
            {
                var detail = service.GetTransactionDetailById(id);
                return Ok(detail);
            }
            catch
            {
                return BadRequest(new { message = "The transaction detail having id " + id + " does not exist in the database." });
            }
        }

        [HttpGet("GetTransactionDetails")]
        public List<TransactionDetail> GetTransactionDetails()
        {
            return service.GetTransactionDetails();
        }

        [HttpPut("UpdateDetail")]
        public IActionResult UpdateDetail(TransactionDetail detail)
        {
            try
            {
                service.UpdateDetail(detail);
                return Ok(new { message = "The transaction detail has been updated successfully." });
            }
            catch
            {
                return BadRequest(new { message = "The transaction detail having id " + detail.Id + " does not exist in the database. It is advised to properly define the property id of the JSON body." });
            }
        }
    }
}
