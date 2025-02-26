using danentang.Dtos;
using danentang.Entity;

namespace danentang.Services.Abstract
{
    public interface IUserService
    {
        UserDto CreateUser(CreateUserDto input);
        void UpdateUser(UpdateUserDto input);
        void DeleteUser(int id);
        List<User> GetAll();
        Task<LoginResponseDto> LoginAsync(LoginDto input);
    }
}
