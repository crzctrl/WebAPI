using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Model for Household
    /// </summary>
    public class Household
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of Household
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Greeting for Household
        /// </summary>
        public string Greeting { get; set; }
        
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Created { get; set; }
    }
}