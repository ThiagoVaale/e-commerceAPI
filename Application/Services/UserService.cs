using Application.Dtos;
using Application.Interfaces;
using Domine.Entities;
using Domine.Enums;
using Domine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public async Task<IEnumerable<User>> CreateUser(CreateUser userRequest)
        //{
        //    User? user = _userRepository.Get(userRequest.Username);
        //}
    }
}
