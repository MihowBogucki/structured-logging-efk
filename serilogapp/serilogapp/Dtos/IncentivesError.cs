using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serilogapp.Dtos
{
    using serilogapp.Enums;

    public class IncentivesError
    {
        public Guid IncentiveId { get; set; }
        public Brand BrandName { get; set; }
        public DateTime DateTime { get; set; }
        public string App { get; set; }

    }
}
