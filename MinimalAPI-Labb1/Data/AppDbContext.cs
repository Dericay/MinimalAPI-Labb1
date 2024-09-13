using Microsoft.EntityFrameworkCore;
using MinimalAPI_Labb1.Models;

namespace MinimalAPI_Labb1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Books>().HasData(new Books()
            {
                ID = 1,
                BookTitle = "Harry Potter",
                Author = "JK Rowling",
                Description = "In the novels, Harry is described as having his father's perpetually untidy black hair, his mother's bright green eyes, and a lightning bolt-shaped scar on his forehead. He is short and skinny for his age, with a thin face and \"knobbly\" knees, and he wears Windsor glasses.",
                Genre = "Fantasy",
                IsAvailable = true,
            });
            modelBuilder.Entity<Books>().HasData(new Books()
            {
                ID = 2,
                BookTitle = "Lord of the rings",
                Author = "Tolken",
                Genre = "Fantasy",
                Description = "The plot of The Lord of the Rings is about the war of the peoples of the fantasy world Middle-earth against a dark lord known as \"Sauron.\" At the same time they try to destroy a ring which would give Sauron a lot of power if he got it, but the only place to destroy the ring is deep into Sauron's land Mordor.",
                IsAvailable = false,
            });
            modelBuilder.Entity<Books>().HasData(new Books()
            {
                ID = 3,
                BookTitle = "StarShip Troopers",
                Author = "Robert Heinlein",
                Genre = "Sci-fi",
                Description = "In the distant future, the Earth is at war with a race of giant alien insects. Little is known about the Bugs except that they are intent on the eradication of all human life. But there was a time before the war... A Mobile Infantry travels to distant alien planets to take the war to the Bugs. They are a ruthless enemy with only one mission: Survival of their species no matter what the cost...",
                IsAvailable = false,
            });
            modelBuilder.Entity<Books>().HasData(new Books()
            {
                ID = 4,
                BookTitle = "The Shining",
                Author = "Stephen King",
                Genre = "Horror",
                Description = " A family heads to an isolated hotel for the winter, where a sinister presence influences the father into violence. At the same time, his psychic son sees horrifying forebodings from both the past and the future.",
                IsAvailable = true,
            });
            modelBuilder.Entity<Books>().HasData(new Books()
            {
                ID = 5,
                BookTitle = "The Guest List",
                Author = "Lucy Foley",
                Genre = "Thriller",
                Description = "The story takes place at the wedding of Jules Keegan and Will Slater, which is being held on an island off the coast of Ireland. The plot has been compared to the works of Agatha Christie, as a murder occurs with limited suspects and each guest has a secret which will be revealed.",
                IsAvailable = true,
            });
        }
    }
}
