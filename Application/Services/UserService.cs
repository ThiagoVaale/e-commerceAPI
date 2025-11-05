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
        private readonly IClientRepository _clientRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHash _passwordHash;
        public UserService(IUserRepository userRepository, IClientRepository clientRepository, IRoleRepository roleRepository, IPasswordHash passwordHash)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _roleRepository = roleRepository;
            _passwordHash = passwordHash;
        }

        public async Task<UserResponse> CreateUser(CreateUser userRequest)
        {
            User? user = await _userRepository.GetAsync(userRequest.Username);

            if (user is not null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be created because it already exists.");
            }

            Role? role = await _roleRepository.GetAsync(RoleType.Client);
            string passwordHashed = _passwordHash.Hash(userRequest.Password);

            User newUser = new User
            {
                Username = userRequest.Username,
                Password = passwordHashed,
                Email = userRequest.Email,
                Role = role,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();

            Membership membership = new Membership
            {
                MembershipType = MembershipType.Bronze,
                DiscountRate = 0m,
                ValidFrom = null,
                ValidTo = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            Client newClient = new Client
            {
                UserID = newUser.Id,
                Address = null,
                Phone = null,
                Membership = membership,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _clientRepository.Add(newClient);
            await _clientRepository.SaveChangesAsync();

            return new UserResponse
            {
                Username = newUser.Username,
                Email = newUser.Email,
                Role = RoleType.Client
            };
        }

        public async Task<UserResponse> UpdateUser(Guid id, UpdateUser updateUser)
        {
            User? user = _userRepository.Get(id);

            if (user is null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be updated because not exists.");
            }

            user.Username = updateUser.Username;
            user.Email = updateUser.Email;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            return new UserResponse
            {
                Username = user.Username,
                Email = user.Email,
            };
        }

        public async Task NewPassword(Guid id, ChangePassword changePassword)
        {
            User? user = _userRepository.Get(id);
            if (user is null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot change password because not exists.");
            }

            bool isValidPassword = _passwordHash.Verify(changePassword.Password, user.Password);

            if (!isValidPassword)
            {
                throw new ConflictException("incorrect operation: The current password is incorrect.");
            }

            string hashedPassword = _passwordHash.Hash(changePassword.NewPassword);
            user.Password = hashedPassword;

            await _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            User? user = _userRepository.Get(id);

            if (user is null)
            {
                throw new ConflictException($"Incorrect operation: The user {user.Username} cannot be deleted because not exists.");
            }

            await _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<List<UserResponse>> Get()
        {
            List<User> users = await _userRepository.GetAsync();

            if (users is null)
            {
                throw new ConflictException("Incorrect operation: There are no users to display.");
            }

            return users.Select(u => new UserResponse
            {
                Username = u.Username,
                Email = u.Email,
                Role = u.Role.Name
            }).ToList();
        }
    }
}
