using System.ComponentModel.DataAnnotations;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ganache.API.Models
{
    public class Wallet
    {
        private readonly IConfiguration _config;

        [Key]
        public string Public_key { get; set; }
        public string Private_key { get; set; }
        public string UserId { get; set; }

    }

}