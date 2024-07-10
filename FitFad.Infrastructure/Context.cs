using FitFad.Domain.Entities;
using FitFad.Domain.Entities.Finances;
using FitFad.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace FitFad.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

        private SqlConnection _connection;

        public Context(SqlConnection connection)
        {
            _connection = connection;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(Client => Client.Id);
            modelBuilder.Entity<Client>()
                .OwnsOne(client => client.Contact)
                .OwnsOne(contact => contact.PhoneNumber);
            modelBuilder.Entity<Client>()
                .OwnsOne(client => client.Contact)
                .OwnsOne(contact => contact.PhoneNumber1);
            modelBuilder.Entity<Client>()
                .OwnsOne(client => client.Contact)
                .OwnsOne(contact => contact.PhoneNumber2);
            modelBuilder.Entity<Client>()
                .OwnsOne(client => client.Address);
            modelBuilder.Entity<Client>()
                .HasMany(client => client.Classes)
                .WithMany(@class => @class.Clients);
            modelBuilder.Entity<Client>()
                .HasMany(client => client.Memberships)
                .WithMany(membership => membership.Clients);
            modelBuilder.Entity<Client>()
                .HasOne(client => client.FinancialAccount)
                .WithOne(account => account.Client)
                .HasForeignKey<FinancialAccount>(account => account.ClientId);

            modelBuilder.Entity<Trainer>()
                .HasKey(trainer => trainer.Id);
            modelBuilder.Entity<Trainer>()
                .OwnsOne(trainer => trainer.Address);
            modelBuilder.Entity<Trainer>()
                .OwnsOne(trainer => trainer.Contact)
                .OwnsOne(contact => contact.PhoneNumber);
            modelBuilder.Entity<Trainer>()
                .OwnsOne(trainer => trainer.Contact)
                .OwnsOne(contact => contact.PhoneNumber1);
            modelBuilder.Entity<Trainer>()
                .OwnsOne(trainer => trainer.Contact)
                .OwnsOne(contact => contact.PhoneNumber2);
            modelBuilder.Entity<Trainer>()
                .HasMany(trainer => trainer.Classes)
                .WithMany(@class => @class.Trainers);

            modelBuilder.Entity<FinancialAccount>()
                .HasKey(account => account.Id);
            modelBuilder.Entity<FinancialAccount>()
                .HasMany(account => account.Transactions)
                .WithOne(transaction => transaction.Account);

            modelBuilder.Entity<Transaction>()
                .HasKey(transaction => transaction.Id);

            modelBuilder.Entity<Membership>()
                .HasKey(Membership => Membership.Id);

            modelBuilder.Entity<Class>()
                .HasKey(@class => @class.Id);
        }
    }
}
