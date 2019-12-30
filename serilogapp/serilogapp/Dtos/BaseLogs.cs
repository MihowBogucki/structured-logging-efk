namespace serilogapp.Dtos
{
    using System;

    public class BaseLog
    {
        public string App { get; set; }
        public string Component { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public string StackTract { get; set; }
    }
}