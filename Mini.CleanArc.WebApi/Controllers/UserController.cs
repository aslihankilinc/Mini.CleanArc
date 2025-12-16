using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini.CleanArc.Core.Application.IContract;
using Mini.CleanArc.Core.Application.Models.UserDto;

namespace Mini.CleanArc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _userService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _userService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserDto dto)
            => Ok(await _userService.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
            => Ok(await _userService.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _userService.DeleteAsync(id));
    }
}
