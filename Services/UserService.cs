using Interfaces;
using Dtos;
using Dtos.Returns;
using Helpers.Objects;
using Models;
using System.ComponentModel.DataAnnotations;


namespace Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task SaveAnNewUser(UserDto userDto)
    {
        var user = userDto.ConvertUserDtoToModel<UserDto, Users>();
        await userRepository.SaveNewUser(user);
    }
    
    public async Task<UserReturnDto> GetUserInSession(UserLoginDto userLoginDto)
    {
        string? userEmail = userLoginDto.Email;
        var userModel = await userRepository.GetUserInSession(userEmail);
        
        if(userModel.Verification == false)
            throw new ValidationException($"Por favor verifica el correo electronico.");

        var userDto = userModel.ConvertUserToDto<Users, UserReturnDto>();
        return userDto;
    }

    public async Task ChangeVerification(string? email)
    {
        await userRepository.ChangeVerification(email);
    }
    
    public async Task<List<UsersFilterDto>> GetAllUser()
    {
        return await userRepository.GetAllUser();
    }
}