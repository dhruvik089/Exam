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
    public class RegistrationServices : IRegistrationInterface
    {
        GameReward_0415Entities _context = new GameReward_0415Entities();
        public bool AddUser(RegistrationModel _registrationModel)
        {

            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                new SqlParameter("@name",_registrationModel.name),
                new SqlParameter("@email",_registrationModel.email),
                new SqlParameter("@password",_registrationModel.password),
                };

                List<RegistrationModel> registrationList = _context.Database.SqlQuery<RegistrationModel>("exec AddUser @name,@email ,@password", sqlParameter).ToList();

                if (registrationList != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
