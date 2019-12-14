using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Model for Budget
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Id of associated Household
        /// </summary>
        public int HouseholdId { get; set; }
        
        /// <summary>
        /// Name of Owner of Budget
        /// </summary>
        public string OwnerId { get; set; }
        
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Name of Budget
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Target Amount for Budget
        /// </summary>
        public double TargetAmount { get; set; }
        
        /// <summary>
        /// Current Amount for Budget
        /// </summary>
        public double CurrentAmount { get; set; }
    }
}