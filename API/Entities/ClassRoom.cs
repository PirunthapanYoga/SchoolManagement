using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ClassRoom
    {

        [Required]
        public int ClassRoomId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual List<Student> Students { get; set; } = new(); 
        
        [Required]
        public virtual List<Teacher> Teachers { get; set; } = new();

    }
}

//Need to add virtual in order to get the data in http get otherwise it will return null as a object even database have objects. 
//It is called as Navigation property
//Virtual keyword enables the entity framework to avoid loading an entity tree of dependent objects which are not needed from the database 