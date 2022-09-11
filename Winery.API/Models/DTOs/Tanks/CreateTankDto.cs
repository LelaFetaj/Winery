namespace Winery.API.Models.DTOs.Tanks
{
    public class CreateTankDto
    {
        public string Code { get; set; }

        public string Type { get; set; }

        public double Volume { get; set; }

        public int Quantity { get; set; }

        public Guid SectorId { get; set; }
    }
}
