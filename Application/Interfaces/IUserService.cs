using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Domine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUser(CreateUser createUser);
        Task<UserResponse> GetUser(Guid id);
        Task<UserResponse> UpdateUser(Guid id, UpdateUser updateUser);
        Task DeleteUser(Guid id);
        Task<User> Login(CredentialsRequest credentialsRequest);
    }
}
