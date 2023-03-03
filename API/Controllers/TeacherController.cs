using System.Text.Json;
using System.Text.Json.Serialization;
using API.Data;
using API.DTO;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SQLitePCL;

namespace API.Controllers
{

    public class TeacherController : BaseAPIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeacherController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterTeacherDto>> Register(RegisterTeacherDto registerTeacherDto)
        {
            var teacher = new Teacher
            {
                FirstName = registerTeacherDto.FirstName,
                LastName = registerTeacherDto.LastName,
                ContactNumber = registerTeacherDto.ContactNumber,
                Email = registerTeacherDto.Email,
            };

            _context.Teachers.Add(teacher);

            await _context.SaveChangesAsync();

            return new RegisterTeacherDto
            {
                ID = teacher.TeacherId,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                ContactNumber = teacher.ContactNumber,
                Email = teacher.Email,
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> getTeacher()
        {
            var teacher = await _context.Teachers
            .Include(p => p.ClassRooms)
            .Include(p => p.Subjects)
            .ThenInclude(p => p.Teachers)
            .ToListAsync();
            var teacherToReturn = _mapper.Map<IEnumerable<TeacherDetailsDto>>(teacher);
            return Ok(teacherToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> getTeacherbyID(int id)
        {
            var teacher = await _context.Teachers
            .Include(p => p.ClassRooms)
            .Include(p => p.Subjects)
            .ThenInclude(p => p.Teachers)
            .SingleOrDefaultAsync(t => t.TeacherId == id); ;
            var teacherToReturn = _mapper.Map<TeacherDetailsDto>(teacher);
            return Ok(teacherToReturn);
        }

        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<Teacher>>> getTeacherNameOnly()
        {
            var teacher = await _context.Teachers.ToListAsync();
            var teacherToReturn = _mapper.Map<IEnumerable<TeacherDetailsOnlyDto>>(teacher);
            return Ok(teacherToReturn);
        }

        [HttpPut("updateSubject")]
        public async Task<IActionResult> UpdateTeacherSubject([FromBody] Teacher teacher)
        {
            try
            {

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                var jsonData = JsonSerializer.Serialize(teacher, jsonSerializerOptions);

                Teacher result = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId);
                result.Subjects = teacher.Subjects;

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpPut("updateClassroom")]
        public async Task<IActionResult> UpdateTeacherClassroom([FromBody] Teacher teacher)
        {
            try
            {
                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                var jsonData = JsonSerializer.Serialize(teacher, jsonSerializerOptions);

                Teacher result = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId);
                result.ClassRooms = teacher.ClassRooms;

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpDelete("deleteSubject/{subjectId}")]
        public async Task<IActionResult> DeleteSubject(int subjectId, [FromBody] Teacher teacher)
        {
            try
            {
                var result = await _context.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId);

                var subject = teacher.Subjects.FirstOrDefault(s => s.ID == subjectId);

                result.Subjects = teacher.Subjects;
                result.Subjects.Remove(subject);

                await _context.SaveChangesAsync();

                return NoContent();


            }catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteClassroom/{classroomId}")]
        public async Task<IActionResult> DeleteClassroom(int classroomId, [FromBody] Teacher teacher)
        {
            try
            {
                var result = await _context.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId);

                var subject = teacher.ClassRooms.FirstOrDefault(s => s.ClassRoomId == classroomId);

                result.ClassRooms = teacher.ClassRooms;
                result.ClassRooms.Remove(subject);

                await _context.SaveChangesAsync();

                return NoContent();


            }catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}