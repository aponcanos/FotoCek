using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace FotoCek.Entities.DbClasses
{
    [Table("Cameras")]
    public class Camera
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string IP { get; set; }
        public int HTTPPort { get; set; }
        public int TCPPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public string RecordingPath { get; set; }
        public int RTSPPort { get; set; }
        public string CameraName { get; set; }
        public string Location { get; set; }
        public int TurnikeID { get; set; }
        public string CameraAlarmParameter { get; set; }

        public string SnapshotCommand { get; set; }
        

    }
}
