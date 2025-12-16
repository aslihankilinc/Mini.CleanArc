using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini.CleanArc.Core.Application.Models.UserDto
{
    // API Response için
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string CreatedAt { get; set; }=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
