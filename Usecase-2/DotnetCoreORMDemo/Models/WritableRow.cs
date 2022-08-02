using System;

namespace DotnetCoreORMDemo.Models
{
    public class WritableRow
    {
        public Guid id { get; set; }
        public DateTime dateTime { get; set; }
        public string text { get; set; }
        public string nickname { get; set; }
    }
}
