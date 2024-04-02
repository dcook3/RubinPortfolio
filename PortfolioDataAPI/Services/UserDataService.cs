using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using PortfolioDataAPI.Models;
using static PortfolioDataAPI.Responses.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RubinPortfolio.Services;

namespace PortfolioDataAPI.Services
{
    public class UserDataService
    {
        private readonly IMongoCollection<ApplicationUser> _users;
        private readonly IConfiguration _configuration;

        public UserDataService(IConfiguration config, IOptions<PortfolioDBSettings> options)
        {
            _configuration = config;
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            _users = mongoDatabase.GetCollection<ApplicationUser>("users");
        }
        /// <summary>
        /// Login functionality method.
        /// </summary>
        /// <param name="model">The DTO representing login.</param>
        /// <returns>A Task<LoginResponse> which represents success/fail and captured data.</returns>
        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser.user == null) return new LoginResponse(false, "Login failed, please try again.");

            if (model.Password != findUser.user.Password) return new LoginResponse(false, "Incorrect email and/or password. Please try again.");

            string jswToken = GenerateToken(findUser.user);
            return new LoginResponse(true, "Login successful.", jswToken);
        }

        /// <summary>
        /// Register functionality method.
        /// </summary>
        /// <param name="model">The DTO representing login.</param>
        /// <returns>A task representing register response record.</returns>
        public async Task<RegistrationResponse> RegisterAsync(ApplicationUser model)
        {
            var response = await GetUser(model.Email);
            var findUser = response.user;
            if (findUser != null) return new RegistrationResponse(false, "User already exists.");
            PasswordHasher hasher = new PasswordHasher();
            try
            {
                await _users.InsertOneAsync(
                new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = hasher.GetHash(model.Password)
                });
                return new RegistrationResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new RegistrationResponse(false, e.Message);
            }
        }

        /// <summary>
        /// Get user data from DB using email.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <returns>A task representing login response record.</returns>
        private async Task<UserResponse> GetUser(string email)
        {
            var filter = Builders<ApplicationUser>.Filter.Where(x => x.Email == email);
            try
            {
                ApplicationUser user = await _users.Find(filter).FirstOrDefaultAsync();
                return new UserResponse(true, "Sucessfully found user record", user);
            }
            catch (Exception e)
            {
                return new UserResponse(false, e.Message);
            }
        }

        // JWT construction helper method.
        private string GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user._id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"]!,
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
