using System.ComponentModel.DataAnnotations;
using API.Extensions;

namespace API.Entities
{
    public class Student
    {
        
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public int ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int ClassRoomId { get; set; }

        public int GetAge(){
            return DateOfBirth.CalculateAge();
        }
    }
}