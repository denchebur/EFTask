using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TaskEF
{
    class Car
    {
        public Car()
        {
           // Owner = new Owner();
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public string RegNumber { get; set; }
        public Owner Owner { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
