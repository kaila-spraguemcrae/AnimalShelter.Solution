namespace PortlandAnimalShelterApi.Models
{
    public class Cat
    {
        public int CatId { get; set; }
        public string Name { get; set; }
        public int AdoptFee { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Personality { get; set; }
    }
}