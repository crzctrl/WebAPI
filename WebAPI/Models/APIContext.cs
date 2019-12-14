using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Enums;

namespace WebAPI.Models
{
    public class APIContext : DbContext
    {
        public APIContext()
            : base("APIConnection")
        {
        }
       
        public static APIContext Create()
        {
            return new APIContext();
        }

        #region Get
        public async Task<Household> GetHousehold(int id)
        {
            return await Database.SqlQuery<Household>("GetHousehold @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<Budget>> GetBudgets(int hhid)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @hhid", new SqlParameter("hhid", hhid)).ToListAsync();
        }

        public async Task<Budget> GetBudgetDetails(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetBudgetItems(int bdgtid)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @bdgtid", new SqlParameter("bdgtid", bdgtid)).ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDetails(int id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<BankAccount>> GetBankAccounts(int hhid)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccounts @hhid", new SqlParameter("hhid", hhid)).ToListAsync();
        }

        public async Task<BankAccount> GetBankAccountDetails(int id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactions(int bacctid)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @bacctid", new SqlParameter("bacctid", bacctid)).ToListAsync();
        }

        public async Task<Transaction> GetTransactionDetails(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }
        #endregion

        #region Add
        public async Task<int> AddBankAccount(int hhId, string ownerId, string name, AccountType acctType, float startingBal, float currBal, float lowBal)
        {

            return await Database.ExecuteSqlCommandAsync("AddBankAccount @hhId, @ownerId, @name, @acctType, @startingBal, @currBal, @lowBal",
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("name", name),
                new SqlParameter("acctType", acctType),
                new SqlParameter("startingBal", startingBal),
                new SqlParameter("currBal", currBal),
                new SqlParameter("lowBal", lowBal));
        }

        public async Task<int> AddBudget(int hhId, string ownerId, string name, float trgtAmount)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @hhId, @ownerId, @name, @trgtAmount",
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("name", name),
                new SqlParameter("trgtAmount", trgtAmount));
        }

        public async Task<int> AddTransaction(int bankAcctId, int budgetItemId, string ownerId, int transTypeId, float amount, string memo)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @bankAcctId, @budgetItemId, @ownerId, @transTypeId, @amount, @memo",
                new SqlParameter("bankAcctId", bankAcctId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("transTypeId", transTypeId),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo));
        }
        #endregion

        #region Update
        public async Task<int> UpdateBankAccount(int id, int hhId, string ownerId, string name, AccountType acctType, float startingBal, float currentBal, float lowBal)
        {
            return await Database.ExecuteSqlCommandAsync("UpdateBankAccount @id, @hhId, @ownerId, @name, @acctType, @startingBal, @currentBal, @lowBal",
                new SqlParameter("id", id),
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("name", name),
                new SqlParameter("acctType", acctType),
                new SqlParameter("startingBal", startingBal),
                new SqlParameter("currentBal", currentBal),
                new SqlParameter("lowBal", lowBal));
        }

        public async Task<int> UpdateBudget(int id, int hhId, string ownerId, string name, float trgtAmount)
        {
            return await Database.ExecuteSqlCommandAsync("UpdateBudget @id, @hhId, @ownerId, @name, @trgtAmount",
                new SqlParameter("id", id),
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("name", name),
                new SqlParameter("trgtAmount", trgtAmount));
        }

        public async Task<int> UpdateTransaction(int id, int bankAcctId, int budgetItemId, string ownerId, int transTypeId, float amount, string memo)
        {
            return await Database.ExecuteSqlCommandAsync("UpdateTransaction @id, @bankAcctId, @budgetItemId, @ownerId, @transTypeId, @amount, @memo",
                new SqlParameter("id", id),
                new SqlParameter("bankAcctId", bankAcctId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("transTypeId", transTypeId),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo));
        }
        #endregion

        #region Delete
        public async Task<int> DeleteBankAccount(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteBankAccount @id",
                new SqlParameter("id", id));
        }

        public async Task<int> DeleteBudget(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteBudget @id",
                new SqlParameter("id", id));
        }

        public async Task<int> DeleteTransaction(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteTransaction @id",
                new SqlParameter("id", id));
        }
        #endregion
    }
}