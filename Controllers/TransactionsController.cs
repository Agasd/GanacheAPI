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
using Microsoft.AspNetCore.Http;
using Ganache.API.Dtos.User;
using Ganache.API.Dtos.Transaction;

namespace Ganache.API.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _repo;

        //Because no living person has enough time to actually figure out how to access an injected dbContext from a static method, and the controllers are created on the fly so I can't even create
        //my WalletController object.
        private readonly IWalletRepository _walletRepo;
        private readonly IUserRepository _userRepo;

        private readonly IConfiguration _config;


        public TransactionsController(ITransactionRepository repo, IWalletRepository walletRepo, IUserRepository userRepo, IConfiguration config)
        {
            _repo = repo;
            _walletRepo = walletRepo;
            _userRepo = userRepo;
            _config = config;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] TransactionCommandDTO transactionDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var token = tokenHandler.ReadJwtToken(accessToken);
            String username = token.Claims.ToArray()[1].ToString().Replace("unique_name: ", string.Empty);
            User userFromRepo = await _userRepo.GetUserInfo(username);
            //return _repo.GetByUserId(username);

            if (userFromRepo != null)
            {

                Wallet senderWallet = _walletRepo.GetById(transactionDTO.Sender_publicKey);
                Wallet recepientWallet = _walletRepo.GetById(transactionDTO.Recepient_publicKey);
                string senderUserId = senderWallet.UserId;
                if (senderWallet != null && username == senderUserId)
                {
                    Transaction dbModel = new Transaction();

                    dbModel.Sender_username = username;
                    dbModel.Recepient_username = recepientWallet.UserId;

                    dbModel.Sender_publicKey = transactionDTO.Sender_publicKey;
                    dbModel.Recepient_publicKey = transactionDTO.Recepient_publicKey;

                    dbModel.Credit_Amount = 0;
                    dbModel.Ether_Amount = transactionDTO.Ether_Amount;
                    dbModel.TransactionDateTime = DateTime.UtcNow;

                    TransactionViewModel tmv = new TransactionViewModel(dbModel);
                   
                    if (true /*await tmv.executeTransaction(_walletRepo.GetById(transactionDTO.Sender_publicKey).Private_key)*/)
                    {
                        await _repo.SaveTransasction(dbModel);
                        return StatusCode(200);
                    }
                    else
                    {
                        return StatusCode(400);
                    }

                }
            }
            return StatusCode(400);
        }
    }
}
