using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Subject
    {
        [Required]        
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}