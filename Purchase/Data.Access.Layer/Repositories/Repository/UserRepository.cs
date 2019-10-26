using System.Linq;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;
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

        public void AddUser(DbUser user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
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