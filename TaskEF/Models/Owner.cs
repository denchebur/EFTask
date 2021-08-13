using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskEF
{
    class Owner
    {
        public Owner()
        {
            Cars = new List<Car>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public string PhoneNumber { get; set; }
        
        public List<Car> Cars { get; set; }
    }
}
