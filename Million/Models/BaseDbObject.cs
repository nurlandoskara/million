using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Models
{
    public class BaseDbObject
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed), DefaultValue("GETUTCDATE()")]
        public DateTime DateCreated { get; set; }
    }
}
