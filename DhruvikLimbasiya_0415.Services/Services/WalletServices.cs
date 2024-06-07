using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Models.ViewModel;
using DhruvikLimbasiya_0415.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                throw e;
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
                throw e;
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
            SqlParameter[] sqlParameter = new SqlParameter[]
               {
                  new SqlParameter("@userId",id),
               };

            int chance = _context.Database.SqlQuery<int>("exec getRemainingChance @userId", sqlParameter).FirstOrDefault();
            return chance;
        }

        public int getAmountInOneDay(int id,int amount)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
               {
                  new SqlParameter("@userId",id),
                  new SqlParameter("@creditAmount",amount)
               };

            int Amount = _context.Database.SqlQuery<int>("exec getAmountInOneDay @userId,@creditAmount", sqlParameter).FirstOrDefault();
            return Amount;
        }

    }
}
