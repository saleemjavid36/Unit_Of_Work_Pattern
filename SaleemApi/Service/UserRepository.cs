using SaleemApi.Context;
using SaleemApi.Interface;
using SaleemApi.Model;

namespace SaleemApi.Service
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(ToDoContext toDoContext) : base(toDoContext)
        {

        }
    }
}
