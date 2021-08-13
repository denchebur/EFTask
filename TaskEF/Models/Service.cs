using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskEF
{
    class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        

    }
    public struct Adress
    {
        public Adress(string city, string street, int house)
        {
            City = city;
            Street = street;
            House = house;
            FullAdress = $"{city} city, {street} st., {house}";
        }
        
        public string FullAdress { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
    }
}
