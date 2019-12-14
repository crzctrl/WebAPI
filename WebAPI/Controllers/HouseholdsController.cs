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
    /// Resource for Household data
    /// </summary>
    [RoutePrefix("Api/Households")]
    public class HouseholdsController : ApiController
    {
        private APIContext db = new APIContext();

        /// <summary>
        /// Get a specific Household
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Household</remarks>
        [Route("GetHousehold"), ResponseType(typeof(Household))]
        public async Task<Household> GetHousehold(int id)
        {
            return await db.GetHousehold(id);
        }

        /// <summary>
        /// Get a specific Household
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        /// <remarks>Returns a specific Household</remarks>
        [Route("GetHouseholdAsJson"), ResponseType(typeof(Household))]
        public async Task<IHttpActionResult> GetHouseholdAsJson(int id)
        {
            var data = await db.GetHousehold(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}
