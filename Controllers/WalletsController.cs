using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Web3;
using Ganache.API.Models;
using Nethereum.Hex.HexConvertors.Extensions;

namespace GanacheAPI.Controllers
{
    [Route("api/[controller]")]
    public class WalletsController : Controller
    {

        /*
         [GET] ether balance using wallet's public key
          /api/wallets/public_key
         */
        [HttpGet("{id}")]
        public string Get(string id)
        {
            try
            {
                return WalletViewModel.getAccountBalance(id).Result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }


        /*
         * [POST]
         * Create wallet: /api/wallets
         */
        [HttpPost]

        public string Post()
        {
            try
            {
                return CreateNewEthereumAddressAsync();

            }
            catch (Exception e)
            {
                return "";
            }
        }


        // PUT api/<controller>/
        [HttpPut]
        public string Put([FromBody]Transaction transaction)
        {
            try
            {
                //transaction.executeTransaction();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }
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
