using AutoMapper;
using E_Commerce_API.DTOS;
using E_Commerce_API.Extensions;
using E_Commerce_API.Identity;
using E_Commerce_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, ITokenService tokenService,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;   
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login ([FromForm]LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if(user == null) return BadRequest("Invalid email or password");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if(!result.Succeeded) return BadRequest("Invalid email or password");

            return new UserDto { DisplayName = user.DisplayName, Email = user.Email, Token = _tokenService.CreateToken(user) };

        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register([FromForm] RegisterDto dto)
        {

            AppUser user = new()
            {
                DisplayName = dto.DisplayName,
                Email = dto.Email,
                UserName = dto.Email
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) return BadRequest();

            return new UserDto { DisplayName = user.DisplayName, Email = user.Email, Token = _tokenService.CreateToken(user) };

        }

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindEmailFromClaims(User);
       
            return new UserDto
            {
                Email= user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("EmailIsExist")]
        public async Task<ActionResult<bool>> EmailIsExist([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpGet("GetCurrentAddress")]
        public async Task<ActionResult<AddressDto>> GetCurrentAddress()
        {
            var user = await _userManager.FindUserByClaimsWithAddress(User);

            return _mapper.Map<Address,AddressDto>(user.Address);

        }

        [HttpPut("UpdateAddress")]
        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto dto)
        {
            var user = await _userManager.FindUserByClaimsWithAddress(User);

            user.Address = _mapper.Map<AddressDto, Address>(dto);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return Ok(_mapper.Map<AddressDto>(user.Address));
            return BadRequest();
        }

    }

 
}
