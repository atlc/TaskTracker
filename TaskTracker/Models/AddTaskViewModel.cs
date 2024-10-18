namespace TaskTracker.Models
{
    public class AddTaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }

    }
}
