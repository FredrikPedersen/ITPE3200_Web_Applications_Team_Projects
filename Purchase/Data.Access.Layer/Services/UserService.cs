using Purchase.Model.DBModels;
using Purchase.Model.ServiceModels;
using System;
using System.Linq;

namespace Purchase.Data.Access.Layer.Services
{
    public class UserService
    {
        private readonly DatabaseContext _databaseContext;

        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddUser(DbUser user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public bool CheckUser(ServiceModelUser user)
        { 
            Console.WriteLine(user.UserName + "CHEEEEEEEEEEEEEEEEEEEEEEEEEEEEEl");
            DbUser dbUser = _databaseContext.Users.FirstOrDefault(u => u.UserName == user.UserName);

            //TODO REMOVE COMMENT HERE
           /* if (dbUser != null)
            {
                Console.WriteLine(dbUser.UserName + "CHEEEEEEEEEEEEEEEEEEEEEEEEEEEEEl");

                byte[] userPassword = VyController.CreateHash(user.Password, dbUser.Salt);
                bool result = dbUser.Password.SequenceEqual(userPassword);
                return result;
            } */

            return false;
        }
        
        
    }
}