using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganache.API.Dtos.Transaction
{
    public class TransactionCommandDTO
    {
        public string Sender_publicKey { get; set; }
        public string Recepient_publicKey { get; set; }
        public long Ether_Amount { get; set; }
    }
}
