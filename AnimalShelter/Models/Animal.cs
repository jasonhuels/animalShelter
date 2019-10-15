using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int ID { get; set; }
    public int SpeciesID { get; set; }
    public virtual Species Species { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime Date { get; set; }
    public string Breed { get; set; }
  }
}