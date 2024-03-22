using System.ComponentModel.DataAnnotations;

namespace webcore.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }

    }
}
