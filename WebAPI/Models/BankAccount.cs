using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enums;

namespace WebAPI.Models
{
    /// <summary>
    /// Model for Bank Account
    /// </summary>
    public class BankAccount
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
        /// Name of Owner of Bank Account
        /// </summary>
        public string OwnerId { get; set; }
        
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Name of Bank Account
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// [0, 1]
        /// </summary>
        public AccountType AccountType { get; set; }
        
        /// <summary>
        /// Starting Balance for Bank Account
        /// </summary>
        public double StartingBalance { get; set; }
        
        /// <summary>
        /// Current Balance for Bank Account
        /// </summary>
        public double CurrentBalance { get; set; }
        
        /// <summary>
        /// Low Balance Threshold for Bank Account
        /// </summary>
        public double LowBalanceThreshold { get; set; }
    }
}