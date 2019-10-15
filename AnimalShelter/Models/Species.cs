using System.Collections.Generic;

namespace AnimalShelter.Models
{
    public class Species
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        
        public Species()
        {
            this.Animals = new HashSet<Animal>();
        }
    }
}