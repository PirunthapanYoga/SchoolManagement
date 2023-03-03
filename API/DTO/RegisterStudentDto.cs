namespace API.DTO
{
    public class RegisterStudentDto
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactPerson { get; set; }

        public int ContactNumber { get; set; }

        public string Email { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public int ClassRoomId { get; set; }      
    }
}