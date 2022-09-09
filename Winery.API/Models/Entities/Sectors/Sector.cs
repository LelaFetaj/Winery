using Winery.API.Models.Entities.Tanks;

namespace Winery.API.Models.Entities.Sectors
{
    public class Sector
    {
        public Guid Id { get; set; } //guid per id unike

        public string Code { get; set; }

        public int IsActive { get; set; }

        public virtual ICollection<Tank> Tanks { get; set; } //lidhja me tabelen tjeter per foreign key
    }
}
