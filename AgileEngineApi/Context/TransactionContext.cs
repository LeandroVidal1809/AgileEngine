using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineApi.Context
{
    public class TransactionContext: DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> TransactionList { get; set; }


        /// <summary>
        /// Return the TransactionList.
        /// </summary>
        /// <returns></returns>
        internal async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionHistory()
        {
                return await this.TransactionList.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Set new transaction.
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        internal async Task<Transaction> SetTransaction(Transaction trans)
        {
           
            if(trans.Amount >= 0)
            {
                AddTransaction(trans);
                trans.DateTime = DateTime.Now;
                await this.SaveChangesAsync();
                return trans;
            }
            throw new Exception();
        }
        /// <summary>
        /// Get transaction by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal async Task<Transaction> GetTransactionById(int id)
        {
            return await this.TransactionList.FindAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Add a transaction in transationList.
        /// </summary>
        /// <param name="trans"></param>
        private void AddTransaction(Transaction trans)
        {
            this.TransactionList.Add(trans);
        }
    }
}
