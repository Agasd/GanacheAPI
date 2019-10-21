using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Hex.HexTypes;

namespace GanacheAPI.Models
{
    public class Transaction
    {

        public string senderPrivateKey { get; set; }
        public string toAddress { get; set; }

        public string amount { get; set; }


        public async void executeTransaction()
        {
            var account = new Account(this.senderPrivateKey);
            var web3 = new Web3(account, Config.GANACHE);
            Decimal amountInDecimal = Decimal.Parse(amount);
            var transaction = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(this.toAddress, amountInDecimal);

        }

    }
}
