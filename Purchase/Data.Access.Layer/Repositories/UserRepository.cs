using System;
using System.Linq;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddUser(DbUser user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public bool CheckUser(RepositoryModelUser user)
        { 
            Console.WriteLine(user.UserName + "CHEEEEEEEEEEEEEEEEEEEEEEEEEEEEEl");
            DbUser dbUser = _databaseContext.Users.FirstOrDefault(u => u.UserName == user.UserName);

            if (dbUser != null)
            {
                Console.WriteLine(dbUser.UserName + "CHEEEEEEEEEEEEEEEEEEEEEEEEEEEEEl");

                byte[] userPassword = Hasher.CreateHash(user.Password, dbUser.Salt);
                bool result = dbUser.Password.SequenceEqual(userPassword);
                return result;
            }

            return false;
        }
        
        
    }
}