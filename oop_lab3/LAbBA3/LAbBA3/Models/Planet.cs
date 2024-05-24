using System.ComponentModel.DataAnnotations.Schema;

namespace LAbBA3.Models
{
    public class Planet
    {
        public int PlanetId { get; set; }
        [ForeignKey("PlanetId")]
        public string? Name { get; set; }
        public int Size { get; set; }

        public ICollection<BufferZone>? Buffer { get; set; }
    }
}
