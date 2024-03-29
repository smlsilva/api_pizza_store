
using Microsoft.EntityFrameworkCore;
using pizzastore.model.pizza;
class Connection : DbContext {

    public DbSet<Pizza> pizzaModel { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured) {
            optionsBuilder.UseMySql("Server=localhost; User Id=root; Database=db_pizza; Password=;", new MySqlServerVersion( new Version(10,4,32) ));
        }
    }

}