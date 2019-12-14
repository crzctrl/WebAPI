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
    /// Resource for Bank Account data
    /// </summary>
    [RoutePrefix("Api/BudgetItems")]
    public class BudgetItemsController : ApiController
    {
        private APIContext db = new APIContext();

        /// <summary>
        /// Get a list of Budget Items
        /// </summary>
        /// <param name="bdgtid">Budget Id</param>
        /// <returns></returns>
        /// <remarks>Returns a list of Budget Items</remarks>
        [Route("GetBudgetItems"), ResponseType(typeof(BudgetItem))]
        public async Task<List<BudgetItem>> GetBudgetItems(int bdgtid)
        {
            return await db.GetBudgetItems(bdgtid);
        }

        /// <summary>
        /// Get a list of Budget Items
        /// </summary>
        /// <param name="bdgtid">Budget Id</param>
        /// <returns></returns>
        /// <remarks>Returns a list of Budget Items</remarks>
        [Route("GetBudgetItemsAsJson"), ResponseType(typeof(BudgetItem))]
        public async Task<IHttpActionResult> GetBudgetItemsAsJson(int bdgtid)
        {
            var data = await db.GetBudgetItems(bdgtid);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get a specific Budget Item
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Budget Item</remarks>
        [Route("GetBudgetItemDetails"), ResponseType(typeof(BudgetItem))]
        public async Task<BudgetItem> GetBudgetItemDetails(int id)
        {
            return await db.GetBudgetItemDetails(id);
        }

        /// <summary>
        /// Get a specific Budget Item
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Budget Item</remarks>
        [Route("GetBudgetItemDetailsAsJson"), ResponseType(typeof(BudgetItem))]
        public async Task<IHttpActionResult> GetBudgetItemDetailsAsJson(int id)
        {
            var data = await db.GetBudgetItemDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}
