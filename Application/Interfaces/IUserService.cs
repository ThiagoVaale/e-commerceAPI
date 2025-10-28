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
        Task<List<UserResponse>> Get();
        Task<UserResponse> CreateUser(CreateUser userRequest);
        Task<UserResponse> UpdateUser(Guid id, UpdateUser updateUser);
        Task NewPassword(Guid id, ChangePassword changePassword);
        Task DeleteUser(Guid id);

    }
}
