using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SaleemApi.Context;
using SaleemApi.Interface;
using SaleemApi.Model;


namespace SaleemApi.Service
{
    public class ToDoRepository :GenericRepository<ToDo> , IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }
        public List<ToDo> GetCompletedTasks(int count)
        {
            return table.Where(t => t.Status == "Completed").ToList();
        }
    }
}
