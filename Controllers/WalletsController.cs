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
            return Wallet.getAccountBalance(id).Result;
        }


        /*
         * [POST]
         * Create wallet: /api/wallets
         */
        [HttpPost]

        public string Post()
        {

            return Wallet.CreateNewEthereumAddressAsync();
        }


        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]Transaction transaction)
        {
            transaction.executeTransaction();
        }

    }
}
