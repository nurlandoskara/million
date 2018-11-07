using System;

namespace Million.Models
{
    public class User: BaseDbObject
    {
        public string Username { get; set; }
        public Guid Hash { get; set; }
    }
}
