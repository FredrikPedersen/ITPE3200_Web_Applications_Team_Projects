using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories.Interfaces;
using Data.Access.Layer.Repositories.Repository;

namespace Business.Logic.Layer
{
    public class UserBLL
    {
        private readonly IUserRepository _userRepository;

        public UserBLL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(DbUser user)
        {
            _userRepository.AddUser(user);
        }

        public bool CheckUser(RepositoryModelUser user)
        {
            return _userRepository.CheckUser(user);
        }
    }
}