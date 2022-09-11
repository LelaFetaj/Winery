namespace Winery.API.Models.DTOs.Sectors
{
    public class UpdateSectorDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }
}
