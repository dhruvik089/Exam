using DhruvikLimbasiya_0415.Api.JwtService;
using DhruvikLimbasiya_0415.AuthorizeFilter;
using DhruvikLimbasiya_0415.Common;
using DhruvikLimbasiya_0415.Helper.Helper;
using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Services.Interface;
using DhruvikLimbasiya_0415.Services.Services;
using DhruvikLimbasiya_0415.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DhruvikLimbasiya_0415.Controllers
{

    //[JwtAuthentication]
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

            try
            {
                if (Request.Cookies["jwt"]!= null)
                {
                string Authorization = Request.Cookies["jwt"].Value;

                    Session["TotalWalletAmount"] = await WebHelper.TotalWalletAmount(Convert.ToInt32(Session["UserId"]), "TotalWalletAmount", Authorization);
                    Session["GetProfitToday"] = await WebHelper.TotalWalletAmount(Convert.ToInt32(Session["UserId"]), "GetOneDayProfit", Request.Cookies["jwt"].Value);
                    Session["GetTotalEarn"] = await WebHelper.TotalWalletAmount(SessionHelper.UserId, "GetTotalEarn", Request.Cookies["jwt"].Value);
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "LoginRegister");
                }
            }
            catch
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public async Task<ActionResult> Play()
        {
            try
            {


                if (Request.Cookies["jwt"] != null)
                {
                string JwtToken = Request.Cookies["jwt"].Value;
                    int chance = await WebHelper.TotalWalletAmount(Convert.ToInt32(Session["UserId"]), "GetChance", JwtToken);
                    Session["Chance"] = chance;

                    int amount = await WebHelper.getAmountInOneDay(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["creditamount"]), "GetAmountInOneDay", Request.Cookies["jwt"].Value);
                    Session["TotalAmountInOneday"] = amount;
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "LoginRegister");
                }
            }
            catch
            {
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        public ActionResult Wallet(int? pageNumber)
        {
            try
            {

                //var transactionsList = _context.TransactionsHistory.ToList();
                var transactionsList = _context.TransactionsHistory.Where(m => m.user_id == SessionHelper.UserId).OrderByDescending(m => m.TransactionDate).ToList();
                int page = pageNumber ?? 1;

                List<TransactionsHistory> PaginationList = Pager<TransactionsHistory>.Pagination(transactionsList, page);

                ViewBag.totalCount = Pager<TransactionsHistory>.totalCount;
                ViewBag.page = Pager<TransactionsHistory>.page;
                ViewBag.pageSize = Pager<TransactionsHistory>.pageSize;
                ViewBag.totalPage = Pager<TransactionsHistory>.totalPage;

                return View(PaginationList);
            }
            catch
            {
                //return View("~/Views/Shared/Error.cshtml");
                return RedirectToAction("Login", "LoginRegister");
            }
        }


        public int updateWalletAmount(int id, int amount)
        {

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

        //public async Task<bool> AddChance(int id)
        //{
        //    try
        //    {

        //        string JwtToken = Request.Cookies["jwt"].Value;
        //        int chance = await WebHelper.TotalWalletAmount(id, "AddChance", JwtToken);
        //        Session["Chance"] = chance;
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

    }
}