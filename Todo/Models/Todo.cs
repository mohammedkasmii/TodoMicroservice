using Todo.Enum;

namespace Todo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State State { get; set; } = State.TODO;
        public int UserId { get; set; } = 1;


    }
}
