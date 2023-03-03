using API.Data;
using API.DTO;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SubjectController : BaseAPIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SubjectController(DataContext Context, IMapper mapper)
        {
            _mapper = mapper;
            _context = Context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<SubjectDetailsDto>> Register(SubjectDetailsDto subjectDetailsDto)
        {
            var subject = new Subject
            {
                Name = subjectDetailsDto.Name,
            };

            _context.Subjects.Add(subject);

            await _context.SaveChangesAsync();
            

            return new SubjectDetailsDto
            {
                Name = subjectDetailsDto.Name,
                ID = subjectDetailsDto.ID,
            };
        }

        [HttpGet("FullDetails")]
        public async Task<ActionResult<IEnumerable<Subject>>> getSubjectfullDetails()
        {
            var subjects = await _context
                            .Subjects
                            .Include(p=>p.Teachers)
                            .ToListAsync();
            var subjectsToRetuen = _mapper.Map<IEnumerable<SubjectDetailsWithTeachersDto>>(subjects);

            return Ok (subjectsToRetuen);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> getSubject()
        {
            var subjects = await _context.Subjects.ToListAsync();
            var subjectsToRetuen = _mapper.Map<IEnumerable<SubjectDetailsDto>>(subjects);

            return Ok (subjectsToRetuen);
        }
    }
}