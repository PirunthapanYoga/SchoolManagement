using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Teacher
    {
        [Required]        
        public int TeacherId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public virtual List<ClassRoom> ClassRooms { get; set; } =new List<ClassRoom>();

        [Required]
        public virtual List<Subject> Subjects { get; set; } =new List<Subject>();
    }
}