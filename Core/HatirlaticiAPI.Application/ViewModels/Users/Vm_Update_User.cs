using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.ViewModels.Users
{
    public class Vm_Update_User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBrith { get; set; }
    }
}
