using System.Text.Json;
using System.Text.Json.Serialization;
using API.Data;
using API.DTO;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPut("updateSubject/{teacherId}/{subjectId}")]
        public async Task<IActionResult> UpdateTeacherSubject(int subjectId , int teacherId)
        {
            try
            {
                var result = await _context
                            .Teachers
                            .Include(t=>t.Subjects)
                            .Include(t=>t.ClassRooms)
                            .FirstOrDefaultAsync(t => t.TeacherId == teacherId);
                
                var subjectToAdd = await _context
                                .Subjects
                                .Include(t=>t.Teachers)
                                .FirstOrDefaultAsync(t=> t.ID == subjectId);

                result.Subjects.Add(subjectToAdd);

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpPut("updateClassroom/{teacherId}/{classRoomId}")]
        public async Task<IActionResult> UpdateTeacherClassroom(int ClassRoomId ,int TeacherId)
        {
            try
            {
                var teacher = await _context
                            .Teachers
                            .Include(t=>t.ClassRooms)
                            .Include(t=>t.Subjects)
                            .FirstOrDefaultAsync(t => t.TeacherId == TeacherId);
                
                var ClassRoomToAdd = await _context
                                    .ClassRooms
                                    .Include(t=>t.Teachers)
                                    .FirstOrDefaultAsync(t=> t.ClassRoomId == ClassRoomId);

                teacher.ClassRooms.Add(ClassRoomToAdd);

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpDelete("deleteClassroom/{teacherId}/{classRoomId}")]
        public async Task<IActionResult> DeleteClassroom(int ClassRoomId,int teacherId)
        {
            try
            {
                var result = await _context.Teachers
                .Include(t=>t.Subjects)
                .Include(t=>t.ClassRooms)
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId);

                result.ClassRooms.RemoveAll(x => x.ClassRoomId == ClassRoomId);
            
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteSubject/{teacherId}/{subjectId}")]
        public async Task<IActionResult> DeleteSubject(int subjectId, int teacherId)
        {
            try
            {
                var result = await _context.Teachers
                .Include(t=>t.Subjects)
                .Include(t=>t.ClassRooms)
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId);

                result.Subjects.RemoveAll(x => x.ID == subjectId);
            
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}