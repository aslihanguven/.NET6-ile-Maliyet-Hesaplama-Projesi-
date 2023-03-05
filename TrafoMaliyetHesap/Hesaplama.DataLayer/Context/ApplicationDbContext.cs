using Hesaplama.DataLayer.Configuration.Concrete;
using Hesaplama.EntityLayer.Abstract;
using Hesaplama.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hesaplama.DataLayer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Hesaplamalar> Hesaplamalar { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new HesaplamalarConfiguration());
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);

        }

        public override int SaveChanges()
        {
            var modifiedentities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string comptuerName = Environment.UserName;
            //string comptuerName = HttpContent.SignIn.Identity.Name;



            DateTime date = DateTime.Now;

            foreach (var item in modifiedentities)
            {
                IBaseEntity entity = item.Entity as IBaseEntity;
                if (item != null)
                {
                    if (entity.Status == Status.Passive)
                    {
                        switch (item.State)
                        {
                            case EntityState.Modified:
                                entity.DeleteComputerName = comptuerName;
                                entity.DeleteDate = date;
                                entity.Status = Status.Passive;
                                break;
                        }
                    }
                    else
                    {
                        switch (item.State)
                        {
                            case EntityState.Modified:
                                entity.ModifiedComputerName = comptuerName;
                                entity.ModifiedDate = date;
                                entity.Status = Status.Modified;
                                break;
                        }
                    }
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedComputerName = comptuerName;
                            entity.CreateDate = date;
                            entity.Status = Status.Active;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}
