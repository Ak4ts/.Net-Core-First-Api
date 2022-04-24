using System.Collections.Generic;
using System.Threading.Tasks;
using FirstProject.Model;

namespace FirstProject.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task<Book> Create(Book book);
        Task Delete(int id);
        Task Update(Book book);
    }
}
