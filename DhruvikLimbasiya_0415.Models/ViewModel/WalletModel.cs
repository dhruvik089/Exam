using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Models.ViewModel
{
   public class WalletModel
    {
        public int Wallet_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> DebitAmount { get; set; }
        public Nullable<int> creditAmout { get; set; }
        public Nullable<int> totalAmount { get; set; }
        public Nullable<System.DateTime> DebitDate { get; set; }
    }
}
