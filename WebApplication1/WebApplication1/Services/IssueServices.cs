using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
 

namespace WebApplication1.Services
{
    public class IssueServices : IIssueServices
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public IssueServices(DbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Issue>> GetAll()
        {
            if (_context is SQLServerDbContext)
                return await (_context as SQLServerDbContext).Models.ToListAsync();
            else if (_context is PostgreSQLDbContext)
                return await (_context as PostgreSQLDbContext).Models.ToListAsync();
            else
                throw new NotSupportedException("Unsupported DbContext type");
        }

        public async Task<Issue> GetById(int id)
        {
            if (_context is SQLServerDbContext)
                return await (_context as SQLServerDbContext).Models.FindAsync(id);
            else if (_context is PostgreSQLDbContext)
                return await (_context as PostgreSQLDbContext).Models.FindAsync(id);
            else
                throw new NotSupportedException("Unsupported DbContext type");
        }

        public async Task Add(Issue issue)
        {
            if (_context is SQLServerDbContext)
                 await (_context as SQLServerDbContext).Models.AddAsync(issue);
            else if (_context is PostgreSQLDbContext)
                await (_context as PostgreSQLDbContext).Models.AddAsync(issue);
            else
                throw new NotSupportedException("Unsupported DbContext type");
      
            await _context.SaveChangesAsync();
        }

        public async Task Update(Issue issue)
        {
            var existingIssue = await GetById(issue.EventId);
            if (existingIssue == null)
                return;

            _context.Entry(existingIssue).CurrentValues.SetValues(issue);

            // Exclude Timestamp and EventId from the check for modifications
            var modifiedProperties = _context.Entry(existingIssue).Properties
                .Where(p => p.Metadata.Name != "Timestamp" && p.Metadata.Name != "EventId")
                .ToList();

            // Check if any non-excluded property has an actual change
            var hasModifiedProperties = modifiedProperties
                .Any(p => !Equals(p.OriginalValue, p.CurrentValue));

            // Update the Timestamp property only if there is an actual change in other properties
            if (hasModifiedProperties)
                existingIssue.Timestamp = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var issue = await GetById(id);
            if (issue == null)
                return;

            if (_context is SQLServerDbContext)
                (_context as SQLServerDbContext).Models.Remove(issue);
            else if (_context is PostgreSQLDbContext)
                (_context as PostgreSQLDbContext).Models.Remove(issue);
            else
                throw new NotSupportedException("Unsupported DbContext type");

            await _context.SaveChangesAsync();

        }
    }
}
