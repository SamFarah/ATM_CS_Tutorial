using ATM.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace ATM.Data;
public class AtmDbContext : DbContext, IAtmDbContext
{
    public AtmDbContext(DbContextOptions<AtmDbContext> options) : base(options) { }

    public override DatabaseFacade Database => base.Database;

    public DbSet<CardHolder> CardHolders { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity) => base.Entry(entity);


    public override EntityEntry Entry(object entity) => base.Entry(entity);

    public override int SaveChanges() => base.SaveChanges();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CardHolder>().HasData(
            new CardHolder(1, "4532772818527395", "1234", "John", "Griffith", 150.31),
            new CardHolder(2, "4532761841325802", "4321", "Ashley", "Jones", 321.13),
            new CardHolder(3, "5128381368581872", "9999", "Frida", "Dickerson", 105.59),
            new CardHolder(4, "6011188364697109", "2468", "Muneeb", "Harding", 851.84),
            new CardHolder(5, "3490693153147110", "4826", "Dawn", "Smith", 54.27));
    }
}
