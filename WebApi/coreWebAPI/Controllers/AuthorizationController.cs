using coreWebAPI.Helper;
using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Data.Repository.Repository.Authoriztion;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthRepository authRepository;
        public AuthorizationController( IAuthRepository authRepository) 
        {
            this.authRepository = authRepository;
        }

        [HttpGet]
        [Route("Login/{Username}/{Password}")]
        public async Task<IActionResult> UserLoginAsync(string Username, string Password)
        {
            if (Username == null || Password == null)
            {
                return Content("Invalid UserName or Password");
            }

            var user = authRepository.GetAllUsersAsync().GetAwaiter().GetResult().FirstOrDefault(x => x.EmailId == Username);

            if (user != null && PasswordHelper.VerifyPassword(Password, user.Password))
            {
                return Content("User is Valid");
                //Jwt Token code and return the same
            }

            return Content("Invalid UserName or Password");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> ResiterUser([FromBody] UsersDTO newUser)
        {
            if (newUser.EmailId == null || newUser.Password == null)
            {
                return BadRequest();
            }
            var user = new Users
            {
                Name = newUser.Name,
                Password = PasswordHelper.HashPassword(newUser.Password),
                EmailId = newUser.EmailId,
                PhoneNo = newUser.PhoneNo
            };

            var createdUser = await authRepository.CreateUserAsync(user);

            var roleList = await authRepository.GetAllRolesAsync();
            foreach (var item in newUser.Roles)
            {
               var role = roleList.FirstOrDefault(x => x.Name == item);
                var user_roles = new User_Roles
                {
                    RolesId = role.Id,
                    UserId = user.Id
                };

                await authRepository.MapRolesWithUser(user_roles);
            }
            return Ok(newUser);
        }

    }
}
