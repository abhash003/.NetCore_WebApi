using Data.Model;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Repository.DataBase;

namespace WebApi.Data.Repository.Repository.Authoriztion
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SchoolDBContext _dBContext;
        public AuthRepository(SchoolDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<Roles>> GetAllRolesAsync()
        {
            return await _dBContext.Roles.ToListAsync();
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _dBContext.Users.ToListAsync();
        }

        public async Task AddRolesAsync(Roles role)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> CreateUserAsync(Users user)
        {
            _dBContext.Users.Add(user);
            await _dBContext.SaveChangesAsync();
            var addedUser = _dBContext.Users.FirstOrDefaultAsync(x => x.EmailId == user.EmailId).Result;
            return addedUser;
        }

        public async Task MapRolesWithUser(User_Roles user_Roles)
        {
            _dBContext.User_Roles.Add(user_Roles);
            await _dBContext.SaveChangesAsync();
        }

        public async Task CreateRolesAsync(Roles roles)
        {
            _dBContext.Roles.Add(roles);
            await _dBContext.SaveChangesAsync();
        }

    }
}
