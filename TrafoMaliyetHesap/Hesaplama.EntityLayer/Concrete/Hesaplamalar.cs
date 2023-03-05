using Hesaplama.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesaplama.EntityLayer.Concrete
{
    public class Hesaplamalar:IBaseEntity
    {
        public int Id { get; set; }
        public string ProjeNo { get; set; }
        public double Guc { get; set; }
        public double AGgerilim { get; set; }
        public double YGgerilim { get; set; }
        public double KazanGenislik { get; set; }
        public double KazanUzunluk { get; set; }
        public double KazanYukseklik { get; set; }
        public double Maliyet { get; set; }


        public DateTime CreateDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string DeleteComputerName { get; set; }
        public string DeleteIP { get; set; }
        public Status Status { get; set; }


    }
}
