using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class UserRepositoryStub : IUserRepository
    {
        public UserRepositoryStub() { }

        public bool AddUser(DbUser user)
        {
            if (user == null)
            {
                throw new Exception("Brukeren du sender inn er tom");
            }

            return true;
        }

        public bool CheckUser(RepositoryModelUser user)
        {
            return user != null;
        }
    }
}