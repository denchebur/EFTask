using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEF
{
    class TypeOfService
    {
        public TypeOfService()
        {
            Appointments = new List<Appointment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsCompleted { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
