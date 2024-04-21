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
        var userDto = userModel.ConvertUserToDto<Users, UserReturnDto>();
        return userDto;
    }
}