using DhruvikLimbasiya_0415.AuthorizeFilter;
using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Services.Interface;
using DhruvikLimbasiya_0415.Services.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DhruvikLimbasiya_0415.Controllers
{


    [CustomAuthorizeFilter]
    public class DashboardController : Controller
    {
        IWalletInterface _wallet;
        GameReward_0415Entities _context = new GameReward_0415Entities();
        public DashboardController()
        {

            _wallet = new WalletServices();
        }

        public ActionResult Dashboard()
        {
            Session["TotalWalletAmount"] = _wallet.totalWalletAmount(Convert.ToInt32(Session["UserId"]));

            return View();
        }

        public ActionResult Play()
        {
            int chance = _wallet.GetChance(Convert.ToInt32(Session["UserId"]));
            Session["Chance"] = chance;

            int amount = _wallet.getAmountInOneDay(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["creditamount"]));
            Session["TotalAmountInOneday"] = amount;

            return View();
        }

        public ActionResult Wallet()
        {
            var transactionsList = _context.TransactionsHistory.ToList();
            return View(transactionsList);
        }

        public int updateWalletAmount(int id, int amount)
        {
            //Session["creditamount"] = amount;

            int Todayamount = _wallet.getAmountInOneDay(id,amount);
            if (Todayamount == 1)
            {
                _wallet.UpdateWalletAmount(id, amount);
                return 1;
            }
            else
            {
                return 0;
            }

        }

    }
}