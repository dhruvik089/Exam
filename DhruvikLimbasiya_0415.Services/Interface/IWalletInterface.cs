using DhruvikLimbasiya_0415.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Services.Interface
{
    public interface IWalletInterface
    {
        bool addWaletData(int id);
        int totalWalletAmount(int id);
        bool UpdateWalletAmount(int id ,int WalletAmount);
        int GetChance(int id);
        int getAmountInOneDay(int id,int amount);
        int AddChance(int id);
        int GetOneDayProfit(int id);
        int GetTotalEarn(int id);
    }
}
