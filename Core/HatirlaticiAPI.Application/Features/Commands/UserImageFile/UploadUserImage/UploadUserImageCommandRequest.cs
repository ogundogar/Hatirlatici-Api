using MediatR;
using Microsoft.AspNetCore.Http;

namespace HatirlaticiAPI.Application.Features.Commands.UserImageFile.UploadUserImage
{
    public class UploadUserImageCommandRequest : IRequest<UploadUserImageCommandResponse>
    {
        public int Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
