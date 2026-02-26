using Todo.Enum;

namespace Todo.Dto
{
    public class TodoIndexResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State State { get; set; }
    }
}
