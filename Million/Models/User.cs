namespace Million.Models
{
    public class User: BaseDbObject
    {
        public string Username { get; set; }
        public string Hash { get; set; }
    }
}
