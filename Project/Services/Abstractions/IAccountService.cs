using Project.DTOs.UserDTOs;

namespace Project;

public interface IAccountService
{
    Task RegisterAsync(UserRegisterDTO dto);
    Task LoginAsync(UserLoginDTO dto);
    Task LogoutAsync();
}
