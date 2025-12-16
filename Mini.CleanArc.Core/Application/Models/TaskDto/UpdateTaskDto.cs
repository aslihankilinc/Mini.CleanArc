using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini.CleanArc.Core.Application.Models.TaskDto
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
