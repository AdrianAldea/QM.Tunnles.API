using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;
using Tunnels.Core.Services;
using Tunnels.DTOs.User;
using Tunnels.Validators;

namespace Tunnels.Controllers {
    /// <summary>
    /// Users Controller
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper) {
            _userService = userService;
            _mapper = mapper;
        }

        #region Post

        /// <summary>
        /// Create a User
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <returns>CreateUserResponse</returns>
        [HttpPost("")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest) {
            var validator = new CreateUserRequestValidator();
            var validationResult = await validator.ValidateAsync(createUserRequest);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // TODO: needs refining on message format, error codes

            var userToCreate = _mapper.Map<CreateUserRequest, User>(createUserRequest);

            await _userService.CreateUser(userToCreate);

            return Ok();
        }

        #endregion

        #region Get

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>GetUserResponse</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute] int id) {
            var user = await _userService.GetUserById(id);

            var getUserResponse = _mapper.Map<User, GetUserResponse>(user);

            return Ok(getUserResponse);
        }

        [HttpGet("validate")]
        public async Task<ActionResult<User>> ValidateUsernameAndPassword([FromQuery] string username, [FromQuery] string password) {
            var user = await _userService.ValidateUsernameAndPassword(username, password);

            if (user != null) {
                var getUserResponse = _mapper.Map<User, GetUserResponse>(user);
                return Ok(getUserResponse);
            }
            else {
                return ValidationProblem("User not found !");
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<List<GetUserResponse>>> GetAllUsers() {
            var users = await _userService.GetAllAUsers();

            List<GetUserResponse> result = new List<GetUserResponse>();
            foreach (var user in users) {
                var getUserResponse = _mapper.Map<User, GetUserResponse>(user);
                result.Add(getUserResponse);
            }
            return Ok(result);
        }

        #endregion
    }
}
