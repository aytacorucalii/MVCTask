using MediClub.Models;
using MediClub.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MediClub.MVC.DAL;

public class AppDbContext : DbContext
{
    public DbSet<Pasient>Pasients { get; set; }
    public DbSet<Doctor> Doctors {  get; set; }
    public DbSet<Appointment>? Appointments { get; set; }
    public DbSet<AppUser>? AppUsers { get; set; }
    public DbSet<AppRole>? AppRoles { get; set; }

	public DbSet<Hospital>? Hospitals { get; set; }
	public DbSet<HospitalDoctor>? HospitalDoctors { get; set; }
	public AppDbContext(DbContextOptions options) : base(options)
    {

    }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<HospitalDoctor>()
			.HasKey(hd => new { hd.HospitalId, hd.DoctorId });

		modelBuilder.Entity<HospitalDoctor>()
			.HasOne(hd => hd.Hospital)
			.WithMany(h => h.HospitalDoctors)
			.HasForeignKey(hd => hd.HospitalId);

		modelBuilder.Entity<HospitalDoctor>()
			.HasOne(hd => hd.Doctor)
			.WithMany(d => d.HospitalDoctors)
			.HasForeignKey(hd => hd.DoctorId);
	}
}