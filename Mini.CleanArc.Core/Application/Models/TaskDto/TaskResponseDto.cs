namespace Mini.CleanArc.Core.Application.Models.TaskDto
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }

        // Kullanıcı bilgilerini de basitleştirerek ekleyebiliriz
        public string? AssignedUserName { get; set; }
    }
}
