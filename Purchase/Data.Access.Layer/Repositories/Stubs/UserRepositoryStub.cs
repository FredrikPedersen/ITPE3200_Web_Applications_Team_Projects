using System;
using System.Collections.Generic;
using System.Text;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    internal class UserRepositoryStub : IUserRepository
    {
        public void AddUser(DbUser user)
        {
            if (user == null)
            {
                throw new Exception("Brukeren du sender inn er tom");
            }
        }

        public bool CheckUser(RepositoryModelUser user)
        {
            if (user == null) return false;
            else return true;
        }
    }
}