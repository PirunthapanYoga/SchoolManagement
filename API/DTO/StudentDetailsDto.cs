using API.Entities;

namespace API.DTO
{
    public class StudentDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactPerson { get; set; }
        public int ContactNumber { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int Age { get; set; }
        public int ClassRoomId { get; set; }
    }
}