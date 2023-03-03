namespace API.DTO
{
    public class ClassRoomStudentReportDto
    {
        public int ClassRoomId { get; set; }

        public string Name { get; set; }
        
        public List<TeacherDetailsDto> Teachers { get; set; }  
    }
}