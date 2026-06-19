using CodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

public class StudentinfoDbContext : DbContext
{
    public StudentinfoDbContext(DbContextOptions<StudentinfoDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.ID);

            entity.Property(e => e.ID)
                  .HasColumnName("StuId")
                  .HasColumnType("int")
                  .UseIdentityColumn(seed: 100, increment: 1);

            entity.Property(e => e.Name)
                  .HasColumnName("StuName")
                  .HasColumnType("varchar(50)");

            entity.Property(e => e.Dob)
                  .HasColumnName("StuDob")
                  .HasColumnType("date");

            entity.Property(e => e.Email)
                  .HasColumnName("StuEmail")
                  .HasColumnType("varchar(100)");

            entity.Property(e => e.Phone)
                  .HasColumnName("StuPhone")
                  .HasColumnType("varchar(20)");

            entity.HasIndex(e => e.Email)
                  .IsUnique()
                  .HasDatabaseName("UQ_Student_Email");
        });
    }
}
