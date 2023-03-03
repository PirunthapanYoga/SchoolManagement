using System.Reflection.Metadata.Ecma335;
using API.Data;
using API.DTO;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ClassRoomController : BaseAPIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClassRoomController(DataContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterClassRoomDto>> Register(RegisterClassRoomDto registerClassRoomDto)
        {   
            var classRoom = new ClassRoom
            {
                Name = registerClassRoomDto.Name
            };

            _context.ClassRooms.Add(classRoom);

            await _context.SaveChangesAsync();

            return new RegisterClassRoomDto{
                ID  = classRoom.ClassRoomId,
                Name = classRoom.Name,
            }; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRoomDetailsDto>>> getClssRoom()
        {
           var classRooms = await _context.ClassRooms
               .Include(p=>p.Students)
               .Include(p=>p.Teachers)
               .ThenInclude(x=>x.Subjects)
               .ToListAsync();
           var classRoomsToReturn = _mapper.Map<IEnumerable<ClassRoomDetailsDto>>(classRooms);
           return Ok (classRoomsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassRoom>> getClassRoom(int id)
        {
            var classRoom = await _context.ClassRooms
                .Include(p=>p.Teachers)
                .ThenInclude(x=>x.Subjects)
                .SingleOrDefaultAsync(x => x.ClassRoomId == id);
            
            var classRoomsToReturn = _mapper.Map<ClassRoomStudentReportDto>(classRoom);
            return Ok(classRoomsToReturn);
        }

        [HttpGet("basicDetails")]
        public async Task<ActionResult<IEnumerable<ClassRoomBasicDetailsDto>>> getBasicDetailsClssRoom()
        {
           var classRooms = await _context.ClassRooms.ToListAsync();
           var classRoomsToReturn = _mapper.Map<IEnumerable<ClassRoomBasicDetailsDto>>(classRooms);
           return Ok (classRoomsToReturn);
        }
    }
}