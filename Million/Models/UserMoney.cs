using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Models
{
    public class UserMoney: BaseDbObject
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public double Money { get; set; }
    }
}
