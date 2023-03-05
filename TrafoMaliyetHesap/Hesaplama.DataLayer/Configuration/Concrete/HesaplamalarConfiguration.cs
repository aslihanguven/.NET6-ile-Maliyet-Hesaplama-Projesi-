using Hesaplama.DataLayer.Configuration.Abstract;
using Hesaplama.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesaplama.DataLayer.Configuration.Concrete
{
    public class HesaplamalarConfiguration:BaseConfiguration<Hesaplamalar>
    {
        public override void Configure(EntityTypeBuilder<Hesaplamalar> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProjeNo).IsRequired(true).HasMaxLength(10);
            builder.Property(x => x.Guc).IsRequired(true);
            builder.Property(x => x.AGgerilim).IsRequired(true);
            builder.Property(x => x.YGgerilim).IsRequired(true);
            builder.Property(x => x.KazanGenislik).IsRequired(true);
            builder.Property(x => x.KazanUzunluk).IsRequired(true);
            builder.Property(x => x.KazanYukseklik).IsRequired(true);
            builder.Property(x => x.Maliyet).IsRequired(true);


            base.Configure(builder);
        }
    }
}
