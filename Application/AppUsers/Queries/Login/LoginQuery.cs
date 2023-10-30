﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Queries.Login
{
    public class LoginQuery : IRequest<AppUserDto>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
