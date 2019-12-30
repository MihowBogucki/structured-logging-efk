using System;

namespace serilogapp.Dtos
{
    using serilogapp.Enums;

    public class IncentivesError : BaseLog
    {
        public Guid IncentiveId { get; set; }
        public Brand BrandName { get; set; }
    }
}
