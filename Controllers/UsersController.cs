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

namespace Ganache.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repo;

        //Because no living person has enough time to actually figure out how to access an injected dbContext from a static method, and the controllers are created on the fly so I can't even create
        //my WalletController object.
        private readonly IWalletRepository _walletRepo;
        private readonly IConfiguration _config;


        public UsersController(IUserRepository repo, IWalletRepository walletRepo, IConfiguration config)
        {
            _repo = repo;
            _walletRepo = walletRepo;
            _config = config;
        }

        [HttpGet]
        [Authorize]
        public async Task<UserInfo> Get()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var token = tokenHandler.ReadJwtToken(accessToken);
            String username = token.Claims.ToArray()[1].ToString().Replace("unique_name: ", string.Empty);
            User userFromRepo = await _repo.GetUserInfo(username);
           
            //return _repo.GetByUserId(username);

            if (userFromRepo != null)
            {
                UserInfo returnUser = new UserInfo();
                returnUser.Username = userFromRepo.Username;
                returnUser.Email = userFromRepo.Email;
                returnUser.Credit = userFromRepo.Credit;
                returnUser.Wallets = _walletRepo.GetByUserId(returnUser.Username);

                return returnUser;
            }
            else
            {
                return null;
            }

        }
    }
}
