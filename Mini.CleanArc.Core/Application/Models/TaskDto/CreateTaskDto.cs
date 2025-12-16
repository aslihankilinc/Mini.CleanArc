using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini.CleanArc.Core.Application.Models.TaskDto
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int AssignedUserId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
