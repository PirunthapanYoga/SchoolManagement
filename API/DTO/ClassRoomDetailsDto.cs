namespace API.DTO
{
    public class ClassRoomDetailsDto
    {
        public int ClassRoomId { get; set; }

        public string Name { get; set; }

        public List<StudentDetailsDto> Students { get; set; }  
        
        public List<TeacherDetailsDto> Teachers { get; set; }  
    }
}