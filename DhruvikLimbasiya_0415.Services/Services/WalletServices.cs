using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Models.ViewModel;
using DhruvikLimbasiya_0415.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Services.Services
{
    public class WalletServices : IWalletInterface
    {
        GameReward_0415Entities _context = new GameReward_0415Entities();
        public bool addWaletData(int id)
        {
            try
            {

                SqlParameter[] sqlParameter = new SqlParameter[]
                    {
                         new SqlParameter("@user_id",id),
                    };
                List<WalletModel> wallet = _context.Database.SqlQuery<WalletModel>("exec Sp_WalletAmount @user_id", sqlParameter).ToList();
                if (wallet.Count != 0)
                {
                    return true;
                }

            }

            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public int totalWalletAmount(int id)
        {
            try
            {

                SqlParameter[] sqlParameter = new SqlParameter[]
                    {
                             new SqlParameter("@user_id",id),
                    };
                WalletModel _walletModel = _context.Database.SqlQuery<WalletModel>("exec TotalWalletAmount @user_id", sqlParameter).FirstOrDefault();
                int totalWalletAmount = Convert.ToInt32(_walletModel.totalAmount);
                return totalWalletAmount;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public bool UpdateWalletAmount(int id, int WalletAmount)
        {

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                     new SqlParameter("@user_id",id),
                     new SqlParameter("@CreditAmount",WalletAmount),
                };

            WalletModel _walletModel = _context.Database.SqlQuery<WalletModel>("exec updateWalletAmount @user_id,@CreditAmount", sqlParameter).FirstOrDefault();

            if (_walletModel != null)
            {
                return true;
            }
            return false;
        }

        public int GetChance(int id)
        {
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
                   {
                  new SqlParameter("@userId",id),
                   };

                int chance = _context.Database.SqlQuery<int>("exec getRemainingChance @userId", sqlParameter).FirstOrDefault();
                return chance;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int getAmountInOneDay(int id, int amount)
        {
            try
            {

                SqlParameter[] sqlParameter = new SqlParameter[]
                   {
                  new SqlParameter("@userId",id),
                  new SqlParameter("@creditAmount",amount)
                   };
                int Amount = _context.Database.SqlQuery<int>("exec getAmountInOneDay @userId,@creditAmount", sqlParameter).FirstOrDefault();
                return Amount;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public int AddChance(int id)
        {
            try
            {

                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                new SqlParameter("@userId",id)
                };

                WalletModel wallet = _context.Database.SqlQuery<WalletModel>("exec AddChance @userId", sqlParameter).FirstOrDefault();

                int chance = GetChance(id);

                return chance;
            }
            catch { return -1; }

        }
        public int GetOneDayProfit(int id)
        {
            try
            {

                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                new SqlParameter("@userid",id)
                };

                int totalProfit = _context.Database.SqlQuery<int>("exec GetTotalProfitInOneDay @userid", sqlParameter).FirstOrDefault();
                return totalProfit;
            }
            catch
            {
                return -1;
            }
        }
        public int GetTotalEarn(int id)
        {
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
              {
                new SqlParameter("@userId",id)
              };

                int amount = _context.Database.SqlQuery<int>("exec GetTotalEarn @userId", sqlParameter).FirstOrDefault();
                return amount;

            }
            catch
            {
                return -1;
            }

        }
    }
}
