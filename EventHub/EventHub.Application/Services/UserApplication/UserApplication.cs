﻿using AutoMapper;
using EventHub.Application.Services.BaseServiceApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Services.BaseService;

namespace EventHub.Application.Services.UserApplication
{
    public class UserApplication : ServiceApplication<UserInput, User, UserDTO>
    {
        public UserApplication(IService<User,UserDTO> service,
        IMapper inputToEntity): base(service, inputToEntity) {}
    }
}
