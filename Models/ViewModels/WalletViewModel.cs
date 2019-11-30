using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganache.API.Models
{
    public class WalletViewModel
    {
        public string userId { get; set; }
        public string publicKey { get; set; }
        public string privateKey { get; set; }

        public WalletViewModel(Wallet wallet)
        {
            this.userId = wallet.UserId;
            this.publicKey = wallet.Public_key;
            this.privateKey = wallet.Private_key;
        }

        public async Task<String> getAccountBalance()
        {
            Web3 web3 = new Web3(Config.GANACHE);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(publicKey);
            return balance.Value.ToString();
        }
    }
}
