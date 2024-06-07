using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DhruvikLimbasiya_0415.Common
{
    public class WebHelper
    {
        public async static Task<Registration> AddUser(RegistrationModel _registrationModel, string action)
        {
            Registration _registrater = new Registration();
            HttpClient client = new HttpClient();
            string content = JsonConvert.SerializeObject(_registrationModel);
            client.BaseAddress = new Uri("http://localhost:52710/api/LoginRegister/");
            HttpResponseMessage response = await client.PostAsync(action, new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                _registrater = JsonConvert.DeserializeObject<Registration>(data);
            }
            return _registrater;
        }

        public async static Task<List<TransactionsHistory>> showTransaction(int userId,string action)
        {
            List<TransactionsHistory> transactionsHistory = new List<TransactionsHistory>();
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52710/api/TransactionHistory/");
            HttpResponseMessage response = await client.GetAsync($"{action}?id={userId}");


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                transactionsHistory = JsonConvert.DeserializeObject<List<TransactionsHistory>>(data);
            }
            return transactionsHistory;
        }

    }
}