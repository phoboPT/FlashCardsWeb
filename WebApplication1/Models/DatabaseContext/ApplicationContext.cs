using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

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
        public virtual DbSet<Course> CourseDetails { get; set; }

        public virtual DbSet<Deck> DeckDetails { get; set; }
        public virtual DbSet<DeckDiscipline> DeckDisciplineDetails { get; set; }

        public virtual DbSet<DeckType> DeckTypeDetails { get; set; }

        public virtual DbSet<Discipline> DisciplineDetails { get; set; }

        public virtual DbSet<DisciplineUser> DisciplineUserDetails { get; set; }
        public virtual DbSet<User> UserDetails { get; set; }
        public virtual DbSet<UserCardAnswer> UserCardAnswerDetails { get; set; }
        public virtual DbSet<UserType> UserTypeDetails { get; set; }
      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AnswerType>().ToTable("AnswerType");
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Deck>().ToTable("Deck");
            modelBuilder.Entity<DeckDiscipline>().ToTable("DeckDiscipline");
            modelBuilder.Entity<DeckType>().ToTable("DeckType");
            modelBuilder.Entity<Discipline>().ToTable("Discipline");
            modelBuilder.Entity<DisciplineUser>().ToTable("DisciplineUser");
            modelBuilder.Entity<UserCardAnswer>().ToTable("UserCardAnswer");
            modelBuilder.Entity<UserType>().ToTable("UserType");
            modelBuilder.Entity<User>().ToTable("User");
          
            
            
        }




    }
}