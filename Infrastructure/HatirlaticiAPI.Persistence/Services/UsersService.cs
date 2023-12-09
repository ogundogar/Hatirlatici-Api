using HatirlaticiAPI.Application.Abstractions;
using HatirlaticiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Infrastructure.Concretes
{
    public class UsersService : IUsersService
    {
        public List<TbUsers> GetUsers() => new() {
            new()
            {
                UserName="Deneme",
                Email="deneme@gamil.com",
                Password="password",
                DateOfBrith=DateTime.Now,
            }
        };
    }
}
