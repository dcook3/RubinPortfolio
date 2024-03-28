using Microsoft.AspNetCore.Mvc;
using PortfolioDataAPI.Services;
using static PortfolioDataAPI.Responses.Responses;
using PortfolioDataAPI.DTOs;
using PortfolioDataAPI.Models;

namespace PortfolioDataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserDataService _userDataService;

        public AccountController(UserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(ApplicationUser model)
        {
            try 
            {
                var response = await _userDataService.RegisterAsync(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            try
            {
                var response = await _userDataService.LoginAsync(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
