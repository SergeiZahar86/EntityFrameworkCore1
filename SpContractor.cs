using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1
{
    public partial class SpContractor
    {
        public int ContractorId { get; set; }
        public string Name { get; set; }
        public bool? Shipper { get; set; }
        public bool? Consigner { get; set; }
    }
}
