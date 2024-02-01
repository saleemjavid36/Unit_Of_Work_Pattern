using SaleemApi.Model;

namespace SaleemApi.Interface
{
    public interface IToDoRepository : IGenericRepository<ToDo>
    {
        List<ToDo> GetCompletedTasks(int count);
    }
}
