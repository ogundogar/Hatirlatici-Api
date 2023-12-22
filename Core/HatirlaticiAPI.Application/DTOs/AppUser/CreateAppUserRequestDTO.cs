using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.DTOs.AppUser
{
    public class CreateAppUserRequestDTO
    {
        public string userName { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
