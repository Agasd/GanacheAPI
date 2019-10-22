using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Web3;
using GanacheAPI.Models;


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
                return Wallet.getAccountBalance(id).Result;
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
                return Wallet.CreateNewEthereumAddressAsync();
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
                transaction.executeTransaction();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }
        }
    }
}
