using SaleemApi.Model;

namespace SaleemApi.Interface
{
    public interface IToDoService
    {
        ToDo AddTask(ToDo todo);
        List<ToDo> GetAllTasks();
        ToDo ToDoGetTaskById(int id);
        ToDo UpdateTask(ToDo todo);
        bool DeleteTaskById(int id);
    }
}
