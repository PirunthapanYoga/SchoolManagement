namespace API.DTO
{
    public class TeacherDetailsDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNumber { get; set; }
        public string Email { get; set; }
        public virtual List<SubjectDetailsWithTeachersDto> Subjects { get; set; }    
        public virtual List<ClassRoomBasicDetailsDto> ClassRooms { get; set; }      
    }
}