using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic.Layer
{
    public class UserBLL
    {
        private readonly IUserRepository _userRepositoryStub;
        private readonly UserRepository _userRepository;

        public UserBLL(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public UserBLL(IUserRepository userRepository)
        {
            _userRepositoryStub = userRepository;
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