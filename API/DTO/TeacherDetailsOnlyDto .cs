using API.Entities;

namespace API.DTO
{
    public class TeacherDetailsOnlyDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNumber { get; set; }
        public string Email { get; set; }
    }
}