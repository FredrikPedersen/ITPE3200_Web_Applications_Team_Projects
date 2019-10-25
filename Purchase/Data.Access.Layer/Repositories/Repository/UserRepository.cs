using System.Linq;
using Data.Access.Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.RepositoryModels;
using Utilities.Logging;
using Utilities.Passwords;

namespace Data.Access.Layer.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool AddUser(DbUser user)
        {
            try
            {
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                ErrorLogger.LogError(ex);
                return false;
            }
        }

        public bool CheckUser(RepositoryModelUser user)
        {
            var dbUser = _databaseContext.Users.FirstOrDefault(u => u.UserName == user.UserName);

            if (dbUser == null) return false;

            var userPassword = Hasher.CreateHash(user.Password, dbUser.Salt);
            var result = dbUser.Password.SequenceEqual(userPassword);
            return result;
        }
    }
}