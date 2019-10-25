using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access.Layer.Repositories
{
    public interface IUserRepository
    {
        void AddUser(DbUser user);

        bool CheckUser(RepositoryModelUser user);
    }
}