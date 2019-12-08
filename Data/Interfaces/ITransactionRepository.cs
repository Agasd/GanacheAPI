using Ganache.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganache.API.Data
{
    public interface ITransactionRepository
    {
        Task<bool> SaveTransasction(Transaction transaction);
    }
}
