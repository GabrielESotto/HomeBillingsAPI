using HomeBillings.Entradas.API.Data.Extensions;
using HomeBillings.Entradas.API.Domain.Entities.Entrada;
using Microsoft.EntityFrameworkCore;

namespace HomeBillings.Entradas.API.Data.Context
{
    public class EntryContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public EntryContext(DbContextOptions<EntryContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public virtual DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntryContext).Assembly);
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
