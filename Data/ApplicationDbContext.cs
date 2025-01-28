using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservationApp.Models;

namespace ReservationApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<ReservationApp.Models.Court> Courts { get; set; } = default!;

public DbSet<ReservationApp.Models.Reservation> Reservation { get; set; } = default!;
}
