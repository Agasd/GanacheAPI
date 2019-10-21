using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GanacheAPI.Models
{
    public class Wallet
    {
        public string publicKey { get; set; }
        public string privateKey { get; set; }



        public static async Task<String> getAccountBalance(String walletPublicKey)
        {
            Web3 web3 = new Web3(Config.GANACHE);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(walletPublicKey);
            return balance.Value.ToString();
        }


        public static String CreateNewEthereumAddressAsync()
        {
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
            var account = new Nethereum.Web3.Accounts.Account(privateKey);

            //don't judge, I'm sure there are 9999 better ways to do it, but googleing would take more time than writing it.
            String returnJson = "{\"privateKey\":\"";
            returnJson += privateKey;
            returnJson += "\",";
            returnJson += "\"publicKey\":\"";
            returnJson += account.Address;
            returnJson += '"';
            returnJson += '}';

            return returnJson;
        }
    }
}
