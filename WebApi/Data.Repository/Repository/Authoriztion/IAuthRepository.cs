using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Repository.Repository.Authoriztion
{
    public interface IAuthRepository
    {
        Task<List<Roles>> GetAllRolesAsync();
        Task<List<Users>> GetAllUsersAsync();

        Task<Users> CreateUserAsync(Users user);

        Task CreateRolesAsync(Roles roles);

        Task AddRolesAsync(Roles role);

        Task MapRolesWithUser(User_Roles user_Roles);

        Task<IEnumerable<string>> GetRolesForUser(Users user);

        Task<Users> GetUserAsync(int id);
    }
}
