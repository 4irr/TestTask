using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Meetup> Meetups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
