using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Model for Budget Item
    /// </summary>
    public class BudgetItem
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Id for associated Budget
        /// </summary>
        public int BudgetId { get; set; }
        
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Name of Budget Item
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Target Amount for Budget Item
        /// </summary>
        public double TargetAmount { get; set; }
        
        /// <summary>
        /// Current Amount for Budget Item
        /// </summary>
        public double CurrentAmount { get; set; }
    }
}