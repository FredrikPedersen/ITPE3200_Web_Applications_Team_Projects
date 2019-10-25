using Data.Access.Layer.Repositories;
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
    }
}