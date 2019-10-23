using System.Linq;
using Vy_TicketPurchase_Core.Business.Users.Model;
using Vy_TicketPurchase_Core.Controllers;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business.Users
{
    public class UserService
    {
        private readonly DatabaseContext _databaseContext;

        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool CheckUser(ServiceModelUser user)
        {
            DbUser dbUser = _databaseContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (dbUser != null)
            {
                byte[] userPassword = VyController.CreateHash(user.Password, dbUser.Salt);
                bool result = dbUser.Password.SequenceEqual(userPassword);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}