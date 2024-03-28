using PortfolioDataAPI.Models;

namespace PortfolioDataAPI.Responses
{
    public class Responses
    {
        public record RegistrationResponse(bool flag = false, string? Message = null);
        public record LoginResponse(bool flag = false, string? Message = null, string? JWTToken = null);
        public record UserResponse(bool flag = false, string? Message = null, ApplicationUser? user = null);
    }
}
