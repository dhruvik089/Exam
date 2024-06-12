using DhruvikLimbasiya_0415.Api.JwtService;
using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Services.Interface;
using DhruvikLimbasiya_0415.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DhruvikLimbasiya_0415.Api.Controllers
{
    public class WalletController : ApiController
    {
        IWalletInterface _wallet;
        GameReward_0415Entities _context = new GameReward_0415Entities();
        public WalletController()
        {

            _wallet = new WalletServices();
        }

        [Route("api/Wallet/TotalWalletAmount")]
        [HttpGet]
        public int TotalWalletAmount(int id)
        {
            JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int totalWalletAmount = _wallet.totalWalletAmount(id);
            return totalWalletAmount;
        }

        [Route("api/Wallet/GetChance")]
        [HttpGet]
        public int GetChance(int id)
        {
            JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int chance = _wallet.GetChance(id);
            return chance;
        }

        [Route("api/Wallet/GetAmountInOneDay")]
        [HttpGet]
        public int GetAmountInOneDay(int id, int amount)
        {
            JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int amountperDay = _wallet.getAmountInOneDay(id, amount);
            return amountperDay;
        }

        [Route("api/Wallet/AddChance")]
        [HttpGet]
        public int AddChance(int id)
        {
            JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int Chance = _wallet.AddChance(id);
            return Chance;
        }

        [Route("api/Wallet/GetOneDayProfit")]
        [HttpGet]
        public int GetOneDayProfit(int id)
        {
            JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int profit = _wallet.GetOneDayProfit(id);
            return profit;
        }

        [Route("api/Wallet/GetTotalEarn")]
        [HttpGet]
        public int GetTotalEarn(int id)
        {
            JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int profit = _wallet.GetTotalEarn(id);
            return profit;
        }
    }
}