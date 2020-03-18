using System;

namespace Business.Models
{
    public class Car : Entity
    {
        public string Plaque { get; set; }
        public string Owner { get; set; }
        public bool Stolen { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public DateTime YearModel { get; set; }
    }
}
