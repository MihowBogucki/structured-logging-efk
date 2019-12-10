using System;

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
