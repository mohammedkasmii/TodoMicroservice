using Todo.Dto;

namespace Todo.Repository
{
    public interface ITodoRepository
    {
        List<TodoIndexResponse> GetAll();
        bool Add(TodoAddRequest request);

        TodoIndexResponse GetById(int id);
        void Update(TodoUpdateRequest request);
        void Delete(int id);



    }
}
