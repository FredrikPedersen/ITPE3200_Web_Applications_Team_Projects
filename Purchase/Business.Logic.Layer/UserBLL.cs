using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic.Layer
{
    internal class UserBLL
    {
        private readonly IUserRepository _userRepository;

        public UserBLL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private void AddUser(DbUser user)
        {
            _userRepository.AddUser(user);
        }

        private bool CheckUser(RepositoryModelUser user)
        {
            return _userRepository.CheckUser(user);
        }
    }
}