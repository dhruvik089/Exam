using DhruvikLimbasiya_0415.AuthorizeFilter;
using DhruvikLimbasiya_0415.Common;
using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Services.Interface;
using DhruvikLimbasiya_0415.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Dashboard()
        {
            //Session["TotalWalletAmount"] = _wallet.totalWalletAmount(Convert.ToInt32(Session["UserId"]));
            Session["TotalWalletAmount"] =await WebHelper.TotalWalletAmount(Convert.ToInt32(Session["UserId"]), "TotalWalletAmount");
            Session["GetProfitToday"] = await WebHelper.TotalWalletAmount(Convert.ToInt32(Session["UserId"]), "GetOneDayProfit");


            return View();
        }

        public async Task<ActionResult> Play()
        {
            int chance = await WebHelper.TotalWalletAmount(Convert.ToInt32(Session["UserId"]), "GetChance");
            Session["Chance"] = chance;

            int amount = await WebHelper.getAmountInOneDay(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["creditamount"]), "GetAmountInOneDay");
            Session["TotalAmountInOneday"] = amount;

            return View();
        }

        public ActionResult Wallet()
        {
            var transactionsList = _context.TransactionsHistory.Where(item => item.user_id == Convert.ToInt32(Session["UserId"])).ToList();
            return View(transactionsList);
        }

        public int updateWalletAmount(int id, int amount)
        {
            //Session["creditamount"] = amount;

            int Todayamount = _wallet.getAmountInOneDay(id, amount);
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

        public async Task<bool> AddChance(int id)
        {
          int chance= await WebHelper.TotalWalletAmount(id, "AddChance");
            Session["Chance"]= chance;
            return true;
        }

    }
}