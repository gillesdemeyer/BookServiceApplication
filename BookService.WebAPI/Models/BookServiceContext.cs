using BookService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookService.WebAPI.Models
{
    public class BookServiceContext : DbContext
    {
        public BookServiceContext(DbContextOptions<BookServiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().ToTable("Publisher")
           .HasData(
            new Publisher
            {
                Id = 1,
                Name = "IT-publishers",
                Country = "UK"
            },
           new Publisher
           {
               Id = 2,
               Name = "FoodBooks",
               Country = "Sweden"
           }
           );

            modelBuilder.Entity<Author>()
                .ToTable("Author")
                .HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Sharp",
                    BirthDate = new DateTime(1980, 5, 20)
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Sophie",
                    LastName = "Netty",
                    BirthDate = new DateTime(1992, 3, 4)
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Elisa",
                    LastName = "Yammy",
                    BirthDate = new DateTime(1996, 8, 12)
                });

            modelBuilder.Entity<Book>()
                .ToTable("Book")
                .HasData(
                new
                {
                    Id = 1,
                    ISBN = "123456789",
                    Title = "Learning C#",
                    Price = 24.99m,
                    Year = 2018,
                    NumberOfPages = 420,
                    FileName = "book1.jpg",
                    AuthorId = 1,
                    PublisherId = 1
                },
                new
                {
                    Id = 2,
                    ISBN = "45689132",
                    Title = "Mastering Linq",
                    Price = 35.99m,
                    Year = 2016,
                    NumberOfPages = 360,
                    FileName = "book2.jpg",
                    AuthorId = 2,
                    PublisherId = 1
                },
                new
                {
                    Id = 3,
                    ISBN = "15856135",
                    Title = "Mastering Xamarin",
                    Price = 50.00m,
                    Year = 2017,
                    NumberOfPages = 360,
                    FileName = "book3.jpg",
                    AuthorId = 1,
                    PublisherId = 1
                },
                new
                {
                    Id = 4,
                    ISBN = "56789564",
                    Title = "Exploring ASP.Net Core 2.0",
                    Price = 45.00m,
                    Year = 2018,
                    NumberOfPages = 360,
                    FileName = "book1.jpg",
                    AuthorId = 2,
                    PublisherId = 1
                },
                new
                {
                    Id = 5,
                    ISBN = "234546684",
                    Title = "Unity Game Development",
                    Price = 70.50m,
                    Year = 2017,
                    NumberOfPages = 420,
                    FileName = "book2.jpg",
                    AuthorId = 2,
                    PublisherId = 1
                },
                new
                {
                    Id = 6,
                    ISBN = "789456258",
                    Title = "Cooking is fun",
                    Price = 52.00m,
                    Year = 2007,
                    NumberOfPages = 40,
                    FileName = "book3.jpg",
                    AuthorId = 3,
                    PublisherId = 2
                },
                new
                {
                    Id = 7,
                    ISBN = "94521546",
                    Title = "Secret recipes",
                    Price = 30.00m,
                    Year = 2017,
                    NumberOfPages = 53,
                    FileName = "book1.jpg",
                    AuthorId = 3,
                    PublisherId = 2
                });

            modelBuilder.Entity<Reader>().ToTable("Reader")
            .HasData(
             new Reader
             {
                 Id = 1,
                 FirstName = "Joe",
                 LastName = "Pageturner"
             },
            new Reader
            {
                Id = 2,
                FirstName = "Linda",
                LastName = "Bookslaughter"
            },
            new Reader
            {
                Id = 3,
                FirstName = "Wendy",
                LastName = "Allreader"
            }
            );

            modelBuilder.Entity<Rating>().ToTable("Rating")
           .HasData(
            new Rating { Id = 1, ReaderId = 1, BookId = 1, Score = 3 },
            new Rating { Id = 2, ReaderId = 1, BookId = 2, Score = 2 },
            new Rating { Id = 3, ReaderId = 2, BookId = 3, Score = 5 },
            new Rating { Id = 4, ReaderId = 2, BookId = 1, Score = 4 },
            new Rating { Id = 5, ReaderId = 3, BookId = 2, Score = 2 },
            new Rating { Id = 6, ReaderId = 3, BookId = 3, Score = 3 });

            modelBuilder.Entity<Publisher>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Author>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Book>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Rating>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Reader>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

        }

        

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }



}
