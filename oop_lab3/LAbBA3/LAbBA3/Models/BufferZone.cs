
using System.ComponentModel.DataAnnotations.Schema;

namespace LAbBA3.Models
{
    public class BufferZone
    {
        public int PlanetId { get; set; }
        [ForeignKey("PlanetId")]
        public Planet? Planet { get; set; }

        public int MoonId { get; set; }
        [ForeignKey("MoonId")]
        public Moon? Moon { get; set; }
    }
}
