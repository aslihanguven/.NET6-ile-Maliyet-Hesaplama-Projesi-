using Hesaplama.EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesaplama.DataLayer.Configuration.Abstract
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.DeleteDate).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.CreatedComputerName).IsRequired(false);
            builder.Property(x => x.CreatedIP).IsRequired(false);
            builder.Property(x => x.ModifiedComputerName).IsRequired(false);
            builder.Property(x => x.ModifiedIP).IsRequired(false);
            builder.Property(x => x.DeleteComputerName).IsRequired(false);
            builder.Property(x => x.DeleteIP).IsRequired(false);
        }
    }
}
