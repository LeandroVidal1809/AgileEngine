using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AgileEngineApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgileEngineApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionContext _context;
        public TransactionController(TransactionContext context)
        {
            _context = context;
        }


        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionHistory()
        {
            try
            {
                var list = await _context.GetTransactionHistory();
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return list;

            }
            catch
            {
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                throw new Exception();
            }
        }

        // GET: api/Transaction/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            try
            {
                var transaction = await _context.GetTransactionById(id);
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return transaction;

            }
            catch
            {
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                throw new Exception();
            }
        }


        // GET: api/Transaction
        [HttpPost] 
        public async Task<Transaction> GenerateTransaction(Transaction trans)
        {
            try
            {
                trans = await _context.SetTransaction(trans);
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return trans;
            }
            catch(Exception ex)
            {
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }
    }
}
