using FluentValidation.Results;
using HomeBillings.Entradas.API.Data.Extensions;
using HomeBillings.Usuario.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBillings.Entradas.API.Data.Context
{
    public class UserContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public UserContext(DbContextOptions<UserContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;

            if (success)
                await _mediator.PublishEvents(this);

            return success;
        }
    }
}
