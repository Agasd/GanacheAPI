using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Hex.HexTypes;
using Microsoft.Extensions.Configuration;

namespace Ganache.API.Models
{
    public class TransactionViewModel
    {
        private readonly IConfiguration _config;

        int id;
        public string senderUsername { get; set; }
        public string recepientUsername { get; set; }
        public string senderPublicKey { get; set; }
        public string recepientPublicKey { get; set; }

        public long creditAmount { get; set; }
        public long etherAmount { get; set; }
        public TransactionViewModel(Transaction transaction)
        {
            this.id = transaction.Id;

            this.senderUsername     = transaction.Sender_username;
            this.recepientUsername  = transaction.Recepient_username;
            
            this.senderPublicKey   = transaction.Sender_publicKey;
            this.recepientPublicKey = transaction.Recepient_publicKey;

            this.creditAmount       = transaction.Credit_Amount;
            this.etherAmount        = transaction.Ether_Amount;

        }

        public async Task<bool> executeTransaction(String privateKey)
        {
            var account = new Account(privateKey);
            var web3 = new Web3(account, Config.GANACHE);
            Decimal amountInDecimal = Decimal.Parse(etherAmount.ToString());
            try
            {
                var transaction = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(this.recepientPublicKey, amountInDecimal);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }

    }
}
