namespace Mini.CleanArc.Core.Domain.Entity
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = "Pending";
        public string DueDate { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; } = null!;
    }
}
