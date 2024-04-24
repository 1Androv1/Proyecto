﻿using Dtos;
using Dtos.Returns;

namespace Interfaces;

public interface IUserService
{
    Task SaveAnNewUser(UserDto userDto);
    Task<UserReturnDto> GetUserInSession(UserLoginDto userLoginDto);
    Task ChangeVerification(string? email);
}