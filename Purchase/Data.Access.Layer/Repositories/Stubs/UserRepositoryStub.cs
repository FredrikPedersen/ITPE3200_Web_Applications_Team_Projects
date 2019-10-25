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
        public UserRepositoryStub()
        {
        }

        public void AddUser(DbUser user)
        {
            if (user == null)
            {
                throw new Exception("Brukeren du sender inn er tom");
            }
        }

        public bool CheckUser(RepositoryModelUser user)
        {
            if (user.UserName == "") return false;
            else if (user.Password == "") return false;
            else return true;
        }
    }
}