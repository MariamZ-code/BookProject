using BookProject.DTOs;

namespace BookProject.Repository
{
    public interface IAuthRepository 
    {
            Task<AuthDto> RegisterAsync(RegisterDto model);
            Task<AuthDto> GetTokenAsync(TokenRequestDto model);
           
        
    }
}
