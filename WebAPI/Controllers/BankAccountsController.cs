using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using WebAPI.Enums;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Resource for Bank Account data
    /// </summary>
    [RoutePrefix("Api/BankAccounts")]
    public class BankAccountsController : ApiController
    {
        private APIContext db = new APIContext();

        /// <summary>
        /// Get a list of Bank Accounts
        /// </summary>
        /// <param name="hhid">Household Id</param>
        /// <returns></returns>
        /// <remarks>Returns a list of Bank Accounts</remarks>
        [Route("GetBankAccounts"), ResponseType(typeof(BankAccount))]
        public async Task<List<BankAccount>> GetBankAccounts(int hhid)
        {
            return await db.GetBankAccounts(hhid);
        }

        /// <summary>
        /// Get a list of Bank Accounts
        /// </summary>
        /// <param name="hhid">Household Id</param>
        /// <returns></returns>
        /// <remarks>Returns a list of Bank Accounts</remarks>
        [Route("GetBankAccountsAsJson"), ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetBankAccountsAsJson(int hhid)
        {
            var data = await db.GetBankAccounts(hhid);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get a specific Bank Account
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Bank Account</remarks>
        [Route("GetBankAccountDetails"), ResponseType(typeof(BankAccount))]
        public async Task<BankAccount> GetBankAccountDetails(int id)
        {
            return await db.GetBankAccountDetails(id);
        }

        /// <summary>
        /// Get a specific Bank Account
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Bank Account</remarks>
        [Route("GetBankAccountDetailsAsJson"), ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetBankAccountDetailsAsJson(int id)
        {
            var data = await db.GetBankAccountDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Insert a new Bank Account
        /// </summary>
        /// <param name="hhId">Id of associated Household</param>
        /// <param name="ownerId">Owner of Bank Account</param>
        /// <param name="name">Name of Bank Account</param>
        /// <param name="acctType">Whether Account Type is a (0) Checking / (1) Savings</param>
        /// <param name="startingBal">Starting Balance of Bank Account</param>
        /// <param name="currBal">Current Balance of Bank Account</param>
        /// <param name="lowBal">Low Balance Threshold for Bank Account</param>
        /// <returns></returns>
        /// <remarks>Inserts a new Bank Account into the system</remarks>
        [HttpPost, Route("AddBankAccount"), ResponseType(typeof(BankAccount))]
        public async Task<int> AddBankAccount(int hhId,string ownerId, string name, AccountType acctType, float startingBal, float currBal, float lowBal)
        {
            return await db.AddBankAccount(hhId, ownerId, name, acctType, startingBal, currBal, lowBal);
        }

        /// <summary>
        /// Update a Bank Account
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <param name="hhId">Id of associated Household</param>
        /// <param name="ownerId">Owner of Bank Account</param>
        /// <param name="name">Name of Bank Account</param>
        /// <param name="acctType">Whether Account Type is a (0) Checking / (1) Savings</param>
        /// <param name="startingBal">Starting Balance of Bank Account</param>
        /// <param name="currentBal">Current Balance of Bank Account</param>
        /// <param name="lowBal">Low Balance Threshold for Bank Account</param>
        /// <returns></returns>
        /// <remarks>Updates an existing Bank Account</remarks>
        [HttpPut, Route("UpdateBankAccount"), ResponseType(typeof(BankAccount))]
        public async Task<int> UpdateBankAccount(int id, int hhId, string ownerId, string name, AccountType acctType, float startingBal, float currentBal, float lowBal)
        {
            return await db.UpdateBankAccount(id, hhId, ownerId, name, acctType, startingBal, currentBal, lowBal);
        }

        /// <summary>
        /// Delete a Bank Account
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Deletes an existing Bank Account</remarks>
        [HttpDelete, Route("DeleteBankAccount"), ResponseType(typeof(BankAccount))]
        public async Task<int> DeleteBankAccount(int id)
        {
            return await db.DeleteBankAccount(id);
        }
    }
}
