using HatirlaticiAPI.Application.Repositories.FileRepository;
using HatirlaticiAPI.Application.Repositories.GroupImageFileRepository;
using HatirlaticiAPI.Application.Repositories.UserImageFileRepository;
using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Application.RequestParameters;
using HatirlaticiAPI.Application.Services;
using HatirlaticiAPI.Application.ViewModels.Users;
using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Persistence.Repositories.GroupImageFileRepository;
using HatirlaticiAPI.Persistence.Repositories.UsersRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HatirlaticiAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private IReadUsersRepository _readUsersRepository;
        readonly private IWriteUsersRepository _writeUsersRepository;
        readonly private IFileService _fileService;
        readonly private IWriteUserImageFileRepository _writeUserImageFileRepository;
        public UsersController(IWriteUsersRepository writeUsersRepository, IReadUsersRepository readUsersRepository, IFileService fileService, IWriteUserImageFileRepository writeUserImageFileRepository)
        {
            _writeUsersRepository = writeUsersRepository;
            _readUsersRepository = readUsersRepository;
            _fileService = fileService;
            _writeUserImageFileRepository= writeUserImageFileRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _readUsersRepository.GetAll(false).Count();
            var Users = _readUsersRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.UserName,
                p.Email,
                p.Password,
                p.DateOfBrith,
                p.CreateDate,
                p.UpdateDate
            }).OrderByDescending(p => p.Id).Skip(pagination.Page * pagination.Size).Take(pagination.Size);
            return Ok(new { totalCount, Users });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _readUsersRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(Vm_Create_User model){
            await _writeUsersRepository.AddAsync(new()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                DateOfBrith = DateTime.Parse(model.DateOfBrith),
            });
            await _writeUsersRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Vm_Update_User model)
        {
            TbUsers user = await _readUsersRepository.GetByIdAsync(model.Id);
            user.UserName= model.UserName;
            user.Email= model.Email;  
            user.Password= model.Password;
            user.DateOfBrith= model.DateOfBrith;
            await _writeUsersRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _writeUsersRepository.RemoveAsync(id);
            await _writeUsersRepository.SaveAsync();
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var datas=await _fileService.UploadAsync("resource/users-images", Request.Form.Files);
            await _writeUserImageFileRepository.AddRangeAsync(datas.Select(d => new TbUserImageFile()
            {
                FileName = d.fileName,
                Path = d.path
            }).ToList());
            await _writeUserImageFileRepository.SaveAsync();
            return Ok();
        }
    }
}
