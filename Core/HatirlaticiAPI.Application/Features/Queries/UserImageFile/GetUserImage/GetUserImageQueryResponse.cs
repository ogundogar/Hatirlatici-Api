using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.UserImageFile.GetUserImage
{
    public class GetUserImageQueryResponse
    {
        public string path { get; set; }
        public string fileName { get; set; }
        public int id { get; set; }
    }
}