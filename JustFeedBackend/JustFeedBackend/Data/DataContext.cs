using Microsoft.EntityFrameworkCore;
using JustFeedBackend.Models;

namespace JustFeedBackend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) { }

        // Set the tables, 

        public DbSet<User>  Users { get; set; }

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish_categories> Dish_categories { get; set; }
        public DbSet<Dish_type> Dish_Types { get; set; }


        // declaretion of the relashioship between the models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturant>()
                .HasOne(res => res.User)
                .WithMany(us => us.Resturants)
                // is possible write only the string in function "HasForeignKey" for create a shodow link and don't write the table in the Model
                .HasForeignKey(res => res.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // build a pivot table with this Syntax
            modelBuilder.Entity<Resturant>()
                .HasMany(res => res.Dish_types)
                .WithMany(typ => typ.Resturants)
                .UsingEntity(pivot => pivot.ToTable("RestDishTypes"));

            modelBuilder.Entity<Dish>()
                .HasOne(dis => dis.Resturant)
                .WithMany(res => res.Dishes)
                .HasForeignKey(res => res.Resturant_id)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Dish>()
                .HasOne(dis => dis.Dish_Categories)
                .WithMany(cat => cat.Dishes)
                .HasForeignKey(dis => dis.Dish_CategoriesID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(ord => ord.Resturant)
                .WithMany(res => res.Orders)
                .HasForeignKey(ord => ord.ResturantID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(ord => ord.User)
                .WithMany(usr => usr.Orders)
                .HasForeignKey(ord => ord.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasMany(ord => ord.Dishes)
                .WithMany(dis => dis.Orders)
                .UsingEntity(pivot => pivot.ToTable("OrderDishes"));
        }

    }
}
