using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workneering.Identity.Application.Services.DTO
{
    public class FaceBookResultDto
    {
        public FaceBookData Data { get; set; }
    }
    public class FaceBookData
    {
        public bool Is_Valid { get; set; }
        public string User_Id { get; set; }
    }
}
