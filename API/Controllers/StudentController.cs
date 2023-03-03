using API.Data;
using API.DTO;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class StudentController : BaseAPIController
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public StudentController(DataContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<RegisterStudentDto>> Register(RegisterStudentDto registerStudentDto)
        {   
            var student = new Student
            {
                FirstName = registerStudentDto.FirstName,
                LastName = registerStudentDto.LastName,
                ContactPerson = registerStudentDto.ContactPerson,
                ContactNumber = registerStudentDto.ContactNumber,
                Email = registerStudentDto.Email,
                DateOfBirth = registerStudentDto.DateOfBirth,
                ClassRoomId = registerStudentDto.ClassRoomId,
            };

            student.Age = student.GetAge();

            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return new RegisterStudentDto{
                ID  = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                ContactPerson = student.ContactPerson,
                ContactNumber = student.ContactNumber,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                ClassRoomId = registerStudentDto.ClassRoomId
            }; 
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDetailsDto>>> getStudent()
        {
            var student = await _context
                .Students
                .ToListAsync();
            
            var studentsToReturn = _mapper.Map<IEnumerable<StudentDetailsDto>>(student);
            return Ok (studentsToReturn);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> getStudent(int id)
        {
            var student =  await _context
                .Students
                .SingleOrDefaultAsync(x => x.Id == id);

            var studentToReturn = _mapper.Map<StudentDetailsDto>(student);

            return Ok (studentToReturn);
        }
        
    }
}