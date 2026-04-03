using Gradution_Project.models;
using Gradution_Project.models;
using Microsoft.EntityFrameworkCore;

namespace Gradution_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<User_Preference> User_Preferences { get; set; }
        public DbSet<Sound_History> Sound_Histories { get; set; }
        public DbSet<Emergency_Alert> Emergency_Alerts { get; set; }
        public DbSet<Pairing> Pairings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Pairing>()
                .HasOne(p => p.DeafUser)
                .WithMany(u => u.DeafPairings)
                .HasForeignKey(p => p.deaf_user_id)
                .OnDelete(DeleteBehavior.Restrict); 

          
            modelBuilder.Entity<Pairing>()
                .HasOne(p => p.Companion)
                .WithMany(u => u.CompanionPairings)
                .HasForeignKey(p => p.compainin_id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Emergency_Alert>()
                .HasOne(a => a.Sender)
                .WithMany(u => u.SentAlerts)
                .HasForeignKey(a => a.sender_id)
                .OnDelete(DeleteBehavior.Restrict);

          
            modelBuilder.Entity<Emergency_Alert>()
                .HasOne(a => a.Receiver)
                .WithMany(u => u.ReceivedAlerts)
                .HasForeignKey(a => a.receiver_id)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}