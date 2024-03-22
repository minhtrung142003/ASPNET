using System.ComponentModel.DataAnnotations;

namespace haminhtrung.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image {  get; set; }
        public int price { get; set; }
    }
}
