using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandRequest:IRequest<DeleteUserCommandResponse>
    {
        public int Id { get; set; }
    }
}
