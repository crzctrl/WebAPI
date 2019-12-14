using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Resource for Transaction data
    /// </summary>
    [RoutePrefix("Api/Transactions")]
    public class TransactionsController : ApiController
    {
        private APIContext db = new APIContext();

        /// <summary>
        /// Get a list of Transactions
        /// </summary>
        /// <param name="bacctid">Bank Account Id</param>
        /// <returns></returns>
        /// <remarks>Reutrns a list of Transactions</remarks>
        [Route("GetTransactions"), ResponseType(typeof(Transaction))]
        public async Task<List<Transaction>> GetTransactions(int bacctid)
        {
            return await db.GetTransactions(bacctid);
        }

        /// <summary>
        /// Get a list of Transactions
        /// </summary>
        /// <param name="bacctid">Bank Account Id</param>
        /// <returns></returns>
        /// <remarks>Reutrns a list of Transactions</remarks>
        [Route("GetTransactionsAsJson"), ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> GetTransactionsAsJson(int bacctid)
        {
            var data = await db.GetTransactions(bacctid);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get a specific Transaction
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Transaction</remarks>
        [Route("GetTransactionDetails"), ResponseType(typeof(Transaction))]
        public async Task<Transaction> GetTransactionDetails(int id)
        {
            return await db.GetTransactionDetails(id);
        }

        /// <summary>
        /// Get a specific Transaction
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Transaction</remarks>
        [Route("GetTransactionDetailsAsJson"), ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> GetTransactionDetailsAsJson(int id)
        {
            var data = await db.GetTransactionDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Insert a new Transaction
        /// </summary>
        /// <param name="bankAcctId">Id of associated Bank Account</param>
        /// <param name="budgetItemId">Id of associated Budget Item</param>
        /// <param name="ownerId">Owner of Transaction</param>
        /// <param name="transTypeId">Whether Transaction Type is a (0) Deposit / (1) Withdrawal</param>
        /// <param name="amount">Amount of Transaction</param>
        /// <param name="memo">Memo for Transaction</param>
        /// <returns></returns>
        /// <remarks>Inserts a new Transaction into the system</remarks>
        [HttpPost, Route("AddTransaction")]
        public async Task<int> AddTransaction(int bankAcctId, int budgetItemId, string ownerId, int transTypeId, float amount, string memo)
        {
            return await db.AddTransaction(bankAcctId, budgetItemId, ownerId, transTypeId, amount, memo);
        }

        /// <summary>
        /// Update a Transaction
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <param name="bankAcctId">Id of associated Bank Account</param>
        /// <param name="budgetItemId">Id of associated Budget Item</param>
        /// <param name="ownerId">Owner of Transaction</param>
        /// <param name="transTypeId">Whether Transaction Type is a (0) Deposit / (1) Withdrawal</param>
        /// <param name="amount">Amount of Transaction</param>
        /// <param name="memo">Memo for Transaction</param>
        /// <returns></returns>
        /// <remarks>Updates existing Transaction</remarks>
        [HttpPut, Route("UpdateTransaction")]
        public async Task<int> UpdateTransaction(int id, int bankAcctId, int budgetItemId, string ownerId, int transTypeId, float amount, string memo)
        {
            return await db.UpdateTransaction(id, bankAcctId, budgetItemId, ownerId, transTypeId, amount, memo);
        }

        /// <summary>
        /// Delete a Transaction
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Deletes an existing Transaction</remarks>
        [HttpDelete, Route("DeleteTransaction")]
        public async Task<int> DeleteTransaction(int id)
        {
            return await db.DeleteTransaction(id);
        }
    }
}
