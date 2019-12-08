using System;
using System.Threading.Tasks;
using Ganache.API.Models;

namespace Ganache.API.Data
{
    public interface IWalletRepository
    {
        Task<bool> Create(Wallet wallet);
        Wallet[] GetByUserId(String username);
        Wallet GetById(String id);

    }
}
