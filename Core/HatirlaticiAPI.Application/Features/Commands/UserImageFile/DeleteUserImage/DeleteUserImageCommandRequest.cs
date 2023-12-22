using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.UserImageFile.DeleteUserImage
{
    public class DeleteUserImageCommandRequest : IRequest<DeleteUserImageCommandResponse>
    {
        public int userId { get; set; }
        public int imageId { get; set; }
    }
}
