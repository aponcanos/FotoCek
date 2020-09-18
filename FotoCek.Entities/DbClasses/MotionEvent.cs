using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoCek.Entities.DbClasses
{
    [Table("MotionEvents")]
    public class MotionEvent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int TurnikeID { get; set; }
        public DateTime GirisTarihi { get; set; }
        public string DosyaIsmi { get; set; }
    }
}
