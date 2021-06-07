using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.DatabaseContext
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=root;Host=localhost;Port=5432;Database=flash_cards;Pooling=true;");
       
        public ApplicationContext()
        {
        }
        public virtual DbSet<AnswerType> AnswerTypeDetails { get; set; }

        public virtual DbSet<Card> CardDetails { get; set; }
        public virtual DbSet<Degree> DegreeDetails { get; set; }

        public virtual DbSet<Deck> DeckDetails { get; set; }
        public virtual DbSet<Discipline> DisciplineDetails { get; set; }

        public virtual DbSet<DisciplineUser> DisciplineUserDetails { get; set; }
        public virtual DbSet<User> UserDetails { get; set; }
        public virtual DbSet<UserCardAnswer> UserCardAnswerDetails { get; set; }
        public virtual DbSet<UserType> UserTypeDetails { get; set; }
      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AnswerType>().ToTable("AnswerType");
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<Degree>().ToTable("Degree");
            modelBuilder.Entity<Deck>().ToTable("Deck");
            modelBuilder.Entity<Discipline>().ToTable("Discipline");
            modelBuilder.Entity<DisciplineUser>().ToTable("DisciplineUser");
            modelBuilder.Entity<UserCardAnswer>().ToTable("UserCardAnswer");
            modelBuilder.Entity<UserType>().ToTable("UserType");
            modelBuilder.Entity<User>().ToTable("User");
          
            
            
        }




    }
}