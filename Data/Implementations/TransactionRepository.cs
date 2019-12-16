using Ganache.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ganache.API.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;
        public TransactionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveTransasction(Transaction transaction)
        {
            try
            {
                await _context.Transactions.AddAsync(transaction); // Adding the transactions to context of wallets.
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
        public async Task<Transaction[]> getAllTransactions()
        {
            var transactions = await _context.Transactions.ToArrayAsync<Transaction>();
            return transactions;
        }
    }
}
