using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1
{
    public partial class SpUsers
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fio { get; set; }
        public string EmplId { get; set; }
    }
}
