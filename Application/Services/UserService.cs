using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Exceptions;
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
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHash _passwordHash;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHash passwordHash)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHash = passwordHash;
        }

        public async Task<UserResponse> CreateUser(CreateUser createUser)
        {
            User? user = await _userRepository.GetAsync(createUser.Username);

            if (user is not null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be created because it already exists.");
            }

            Role? role = await _roleRepository.GetAsync(RoleType.User);
            string passwordHashed = _passwordHash.Hash(createUser.Password);

            User newUser = new User
            {
                Username = createUser.Username,
                Password = passwordHashed,
                Email = createUser.Email,
                Role = role,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();

            return new UserResponse
            {
                Username = newUser.Username,
                Email = newUser.Email,
                Role = newUser.Role.Name
            };
        }

        public async Task<UserResponse> GetUser(Guid id)
        {
            User? user = _userRepository.Get(id);

            if (user is null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be retrieved because not exists.");
            }

            return new UserResponse
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        public async Task<UserResponse> UpdateUser(Guid id, UpdateUser updateUser)
        {
            User? user = _userRepository.Get(id);

            if (user is null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be updated because not exists.");
            }

            user.Email = updateUser.Email;
            user.Username = updateUser.Username;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            return new UserResponse
            {
                Username = user.Username,
                Email = user.Email,
            };
        }
  
        public async Task DeleteUser(Guid id)
        {
            User? user = _userRepository.Get(id);

            if (user is null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be deleted because not exists.");
            }

            if (user.DeletedAt != null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be deleted because it is already deleted.");
            }

            user.DeletedAt = DateTime.UtcNow;
            user.Password = null;

            await _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<User> Login(CredentialsRequest credentialsRequest)
        {
            User? user = await _userRepository.GetUserForLoginAsync(credentialsRequest.Username);

            bool validPassword = _passwordHash.Verify(credentialsRequest.Password, user.Password);

            if (user is null || !validPassword)
            {
                throw new UnauthorizedException("Incorrect operation: Incorrect username or password");
            }

            return user;
        }
    }
}
