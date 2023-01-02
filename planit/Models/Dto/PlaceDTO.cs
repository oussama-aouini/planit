using System.ComponentModel.DataAnnotations;

namespace planit.Models.Dto
{
    public class PlaceDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
