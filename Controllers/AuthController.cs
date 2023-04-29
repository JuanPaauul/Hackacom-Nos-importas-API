using appPrevencionRiesgos.Model.Security;
using appPrevencionRiesgos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using appPrevencionRiesgos.Services.Security;

namespace appPrevencionRiesgos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMongoDBServices userService;

        public AuthController(IMongoDBServices userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<List<UserInformationModel>> Get()
        {

            return await userService.GetAsync();
        }
        // /api/auth/userx  
        [HttpPost("User")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserInformationModel model)
        {
            await userService.CreateAsync(model);

            return CreatedAtAction(nameof(Get), new { mail = model.Email }, model);
        }

       
    }
}
