﻿using EventHub.Application.Services.UserApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain;
using EventHub.WebApi.Controllers.BaseController;

namespace EventHub.WebApi.Controllers
{
    public class UserController : Controller<UserInput, Usuario>
    {
        public UserController(UserApplication userService) : base(userService) {}
    }
}
