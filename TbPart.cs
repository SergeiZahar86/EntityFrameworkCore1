using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1
{
    public partial class TbPart
    {
        public TbPart()
        {
            TbCar = new HashSet<TbCar>();
        }

        public Guid PartId { get; set; }
        public string Oper { get; set; }
        public int? NumIzm { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? NumMetering { get; set; }

        public virtual ICollection<TbCar> TbCar { get; set; }
    }
}
