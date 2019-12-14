using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enums;

namespace WebAPI.Models
{
    /// <summary>
    /// Model for Transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Id of associated Bank Account
        /// </summary>
        public int BankAccountId { get; set; }
        
        /// <summary>
        /// Id for associated Budget Item
        /// </summary>
        public int? BudgetItemId { get; set; }
        
        /// <summary>
        /// Name of Owner of Transaction
        /// </summary>
        public string OwnerId { get; set; }
        
        /// <summary>
        /// [0, 1]
        /// </summary>
        public TransactionType TransactionTypeId { get; set; }
        
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Amount for Transaction
        /// </summary>
        public float Amount { get; set; }
        
        /// <summary>
        /// Memo for Transaction
        /// </summary>
        public string Memo { get; set; }
    }
}