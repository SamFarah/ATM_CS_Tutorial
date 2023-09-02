using ATM.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ATM.Data;
public interface IAtmDbContext
{
    DatabaseFacade Database { get; }
    DbSet<CardHolder> CardHolders { get; set; }
    DbSet<Transaction> Transactions { get; set; }

    EntityEntry Entry(object entity);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    int SaveChanges();
}