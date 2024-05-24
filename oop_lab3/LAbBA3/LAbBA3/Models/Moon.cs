using System.ComponentModel.DataAnnotations.Schema;

namespace LAbBA3.Models
{
    public class Moon
    {
        public int MoonId { get; set; }
        [ForeignKey("MoonId")]
        public string? Name { get; set; }
        public int Size { get; set; }

        public ICollection<BufferZone>? Buffer { get; set; }
    }
}
