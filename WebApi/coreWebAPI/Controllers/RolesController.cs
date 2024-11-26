using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.Repository.Authoriztion;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IAuthRepository authRepository;
        public RolesController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateRoles([FromBody] RolesDTO roles)
        {
            var role = new Roles
            {
                Name = roles.Name
            };

             await authRepository.CreateRolesAsync(role);

            return Ok(role);
        }
    }
}
