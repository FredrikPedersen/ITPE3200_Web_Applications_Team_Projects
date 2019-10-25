using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool AddUser(DbUser user);

        bool CheckUser(RepositoryModelUser user);
    }
}