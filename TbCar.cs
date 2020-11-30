using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1
{
    public partial class TbCar
    {
        public Guid PartId { get; set; }
        public int CarId { get; set; }
        public string Num { get; set; }
        public int AttCode { get; set; }
        public double? Tara { get; set; }
        public double? TaraE { get; set; }
        public int? ZoneE { get; set; }
        public int? CauseId { get; set; }
        public double? CarryingE { get; set; }
        public DateTime? AttTime { get; set; }
        public int? Shipper { get; set; }
        public int? Consigner { get; set; }
        public int? Mat { get; set; }
        public double? LeftTruck { get; set; }
        public double? RightTruck { get; set; }
        public double? Brutto { get; set; }
        public double? Netto { get; set; }
        public DateTime? WeighingTime { get; set; }

        public virtual TbPart Part { get; set; }
    }
}
