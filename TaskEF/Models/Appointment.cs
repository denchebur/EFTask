using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskEF
{
    class Appointment
    {

        public Appointment()
        {
            TypeOfServices = new List<TypeOfService>();
            Car = new Car();            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Car Car { get; set; }
        public Service Service { get; set; }
        public DateTime VisitDate { get; set; }
        public Status _Status { get; set; }
        public List<TypeOfService> TypeOfServices { get; set; }
        public enum Status
        {
            InQueue,
            InProccess,            
            Completed,
            Canceled
        }
    }
}
