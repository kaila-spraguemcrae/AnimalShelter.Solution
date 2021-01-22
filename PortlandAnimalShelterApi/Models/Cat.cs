using System.ComponentModel.DataAnnotations;

namespace PortlandAnimalShelterApi.Models
{
    public class Cat
    {
        public int CatId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float AdoptFee { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public string Personality { get; set; }
    }
}