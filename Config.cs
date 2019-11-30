using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganache.API
{
    /*
        This class exists because
        I felt that it would be an
        overkill to include the config 
        object of appsettings for every
        viewmodel constructor
    */
    public class Config
    {
        public static readonly String GANACHE = "HTTP://127.0.0.1:7545";
    }
}
