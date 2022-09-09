
using Winery.API.Models.Entities.Sectors;

namespace Winery.API.Models.Entities.Tanks
{
    public class Tank
    {
        public Guid Id { get; set; } //guid per id unike

        public string Code { get; set; }

        public string Type { get; set; }

        public double Volume { get; set; }

        public int Quantity { get; set; }

        public Guid SectorId { get; set; } //foreign key

        public virtual Sector Sector { get; set; } //lidhja me tablen tjeter per foreign key

    }
}
