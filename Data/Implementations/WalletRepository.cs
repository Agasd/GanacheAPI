using Ganache.API.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ganache.API.Data
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _context;
        public WalletRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Wallet wallet)
        {
            try
            {
                await _context.Wallets.AddAsync(wallet); // Adding the wallet to context of wallets.
                await _context.SaveChangesAsync();
                return true;
            }
            catch(System.Exception e)
            {
                return false;
            }

        }
        public Wallet[] GetByUserId(string username)
        {
            Wallet[] wallets = _context.Wallets.Where(x => x.UserId == username).ToArray<Wallet>();
            if (wallets == null)
                return null;

            return wallets;
        }
    }

}