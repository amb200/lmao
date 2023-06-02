using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IIssueServices
    {
        Task<IEnumerable<Issue>> GetAll();
        Task<Issue> GetById(int id);
        Task Add(Issue issue);
        Task Update(Issue issue);
        Task Delete(int id);
    }
}
