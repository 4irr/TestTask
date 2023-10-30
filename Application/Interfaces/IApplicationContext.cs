using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Event> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
