using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Web3;
using Ganache.API.Models;
using Nethereum.Hex.HexConvertors.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Ganache.API.Data;

namespace Ganache.API.Controllers
{
    [Route("api/[controller]")]
    public class WalletsController : Controller
    {
        private readonly IWalletRepository _repo;
        private readonly IConfiguration _config;

        public WalletsController(IWalletRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        /*
         [GET] ether balance using wallet's public key
          /api/wallets/public_key
         */
        [HttpGet("{id}")]
        public string Get(string id)
        {
            WalletViewModel wallet = new WalletViewModel(new Wallet());
            wallet.publicKey = id;
            try
            {
                return wallet.getAccountBalance().Result;
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
        [Authorize]
        public async Task<String> Post()
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var token = tokenHandler.ReadJwtToken(accessToken);
            String username = token.Claims.ToArray()[1].ToString().Replace("unique_name: ", string.Empty);

            Wallet wallet = new Wallet();
            wallet.UserId = username;

            CreateNewEthereumAddressAsync(ref wallet);
            await _repo.Create(wallet);

            String returnJson = "{\"privateKey\":\"";

            //don't judge, I'm sure there are 9999 better ways to do it, but googleing would take more time than writing it.
            returnJson += wallet.Private_key;
            returnJson += "\",";
            returnJson += "\"publicKey\":\"";
            returnJson += wallet.Public_key;
            returnJson += '"';
            returnJson += '}';

            return returnJson;

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

        public static void CreateNewEthereumAddressAsync(ref Wallet wallet)
        {
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
            var account = new Nethereum.Web3.Accounts.Account(privateKey);

            wallet.Private_key = privateKey;
            wallet.Public_key = account.Address;

        }
    }
}
