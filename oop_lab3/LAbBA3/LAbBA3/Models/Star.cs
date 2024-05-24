using System.ComponentModel.DataAnnotations.Schema;

namespace LAbBA3.Models
{
    public class Star
    {
        public int StarId { get; set; }
        [ForeignKey("StarId")]

        public string? Name { get; set; }
        public int Size { get; set; }
    }
}
