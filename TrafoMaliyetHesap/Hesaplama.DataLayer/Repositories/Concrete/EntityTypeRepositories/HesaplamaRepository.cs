using Hesaplama.DataLayer.Context;
using Hesaplama.DataLayer.Repositories.Concrete.Abstract;
using Hesaplama.DataLayer.Repositories.Interfaces.EntityTypeRepositories;
using Hesaplama.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesaplama.DataLayer.Repositories.Concrete.EntityTypeRepositories
{
    public class HesaplamaRepository : BaseRepository<Hesaplamalar>, IHesaplamaRepository
    {
        public HesaplamaRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }
    }
}
