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
    /// Resource for Budget data
    /// </summary>
    [RoutePrefix("Api/Budgets")]
    public class BudgetsController : ApiController
    {
        private APIContext db = new APIContext();

        /// <summary>
        /// Get a list of Budgets
        /// </summary>
        /// <param name="hhid">Household Id</param>
        /// <returns></returns>
        /// <remarks>Returns a list of Budgets</remarks>
        [Route("GetBudgets"), ResponseType(typeof(Budget))]
        public async Task<List<Budget>> GetBudgets(int hhid)
        {
            return await db.GetBudgets(hhid);
        }

        /// <summary>
        /// Get a list of Budgets
        /// </summary>
        /// <param name="hhid">Household Id</param>
        /// <returns></returns>
        /// <remarks>Returns a list of Budgets</remarks>
        [Route("GetBudgetsAsJson"), ResponseType(typeof(Budget))]
        public async Task<IHttpActionResult> GetBudgetsAsJson(int hhid)
        {
            var data = await db.GetBudgets(hhid);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get a specific Budget
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Budget</remarks>
        [Route("GetBudgetDetails"), ResponseType(typeof(Budget))]
        public async Task<Budget> GetBudgetDetails(int id)
        {
            return await db.GetBudgetDetails(id);
        }

        /// <summary>
        /// Get a specific Budget
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Budget</remarks>
        [Route("GetBudgetDetailsAsJson"), ResponseType(typeof(Budget))]
        public async Task<IHttpActionResult> GetBudgetDetailsAsJson(int id)
        {
            var data = await db.GetBudgetDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Insert a new Budget
        /// </summary>
        /// <param name="hhId">Id of associated Household</param>
        /// <param name="ownerId">Owner of Budget</param>
        /// <param name="name">Name of Budget</param>
        /// <param name="trgtAmount">Target Ammount for Budget</param>
        /// <returns></returns>
        /// <remarks>Inserts a new Budget into the system</remarks>
        [HttpPost, Route("AddBudget")]
        public async Task<int> AddBudget(int hhId, string ownerId, string name, float trgtAmount)
        {
            return await db.AddBudget(hhId, ownerId, name, trgtAmount);
        }

        /// <summary>
        /// Update a Budget
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <param name="hhId">Id of associated Household</param>
        /// <param name="ownerId">Owner of Budget</param>
        /// <param name="name">Name of Budget</param>
        /// <param name="trgtAmount">Target Amount for Budget</param>
        /// <returns></returns>
        /// <remarks>Updates an existing Budget</remarks>
        [HttpPut, Route("UpdateBudget")]
        public async Task<int> UpdateBudget(int id, int hhId, string ownerId, string name, float trgtAmount)
        {
            return await db.UpdateBudget(id, hhId, ownerId, name, trgtAmount);
        }

        /// <summary>
        /// Delete a Budget
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Deletes an existing Budget</remarks>
        [HttpDelete, Route("DeleteBudget")]
        public async Task<int> DeleteBudget(int id)
        {
            return await db.DeleteBudget(id);
        }
    }
}
