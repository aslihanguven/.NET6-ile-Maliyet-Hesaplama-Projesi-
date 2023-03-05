using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesaplama.EntityLayer.Abstract
{
    public enum Status { Active = 1, Modified = 2, Passive = 3 }
    public interface IBaseEntity
    {
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
