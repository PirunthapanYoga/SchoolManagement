namespace API.DTO
{
    public class SubjectDetailsWithTeachersDto
    {
        public int ID { get; set; }
         
        public string Name { get; set; }

        public List<TeacherDetailsOnlyDto> Teachers { get; set; }
    }
}