using Microsoft.Data.SqlClient;
using Todo.Dto;
using Todo.Enum;

namespace Todo.Repository
{
    public class TodoRepository
    {
        IConfiguration conf;


        public TodoRepository(IConfiguration conf)
        {
            this.conf = conf;
        }

         public string GetConnectionString()
        {
            return conf.GetConnectionString("DefaultConnection");
        }

        public List<TodoIndexResponse> GetAll()
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Todo", con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<TodoIndexResponse> todos = new List<TodoIndexResponse>();
            while (reader.Read())
            {
                TodoIndexResponse todo = new TodoIndexResponse();
                todo.Id = reader.GetInt32(0);
                todo.Title = reader.GetString(1);
                todo.Description = reader.GetString(2);
                todo.DateLimite = reader.GetDateTime(3);
                todo.State = (State)reader.GetInt32(4);
                todos.Add(todo);

            }
            con.Close();
            return todos;
        }

        public void Add(TodoAddRequest request)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Todo (Title, Description, DateLimite, State) VALUES (@Title, @Description, @DateLimite, @State)", con);
            cmd.Parameters.AddWithValue("@Title", request.Title);
            cmd.Parameters.AddWithValue("@Description", request.Description);
            cmd.Parameters.AddWithValue("@DateLimite", request.DateLimite);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public TodoIndexResponse GetById(int id)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Todo WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            TodoIndexResponse todo = null;
            if (reader.Read())
            {
                todo = new TodoIndexResponse();
                todo.Id = reader.GetInt32(0);
                todo.Title = reader.GetString(1);
                todo.Description = reader.GetString(2);
                todo.DateLimite = reader.GetDateTime(3);
                todo.State = (State)reader.GetInt32(4);
            }
            con.Close();
            return todo;


        }
}
