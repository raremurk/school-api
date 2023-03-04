using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using AutoMapper;
using School.ViewModels;

namespace School.Controllers
{
    [Route("api/timetable")]
    [ApiController]
    public class SchoolDaysController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public SchoolDaysController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolDayDTO>>> GetSchoolDays()
        {
            var context = await _context.SchoolDays
                .Include(x => x.Lesson1)
                .Include(x => x.Lesson2)
                .Include(x => x.Lesson3)
                .Include(x => x.Lesson4)
                .Include(x => x.Lesson5)
                .Include(x => x.Lesson6)
                .Include(x => x.Lesson7)
                .ToListAsync();
            var answer = _mapper.Map<List<SchoolDay>, List<SchoolDayDTO>>(context);
            return answer;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDay>> GetSchoolDay(int id)
        {
            var schoolDay = await _context.SchoolDays.FindAsync(id);

            if (schoolDay == null)
            {
                return NotFound();
            }

            return schoolDay;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolDay(int id, SchoolDay schoolDay)
        {
            if (id != schoolDay.Id)
            {
                return BadRequest();
            }

            _context.Entry(schoolDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolDayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SchoolDay>> PostSchoolDay(SchoolDay schoolDay)
        {
            _context.SchoolDays.Add(schoolDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchoolDay", new { id = schoolDay.Id }, schoolDay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolDay(int id)
        {
            var schoolDay = await _context.SchoolDays.FindAsync(id);
            if (schoolDay == null)
            {
                return NotFound();
            }

            _context.SchoolDays.Remove(schoolDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolDayExists(int id)
        {
            return _context.SchoolDays.Any(e => e.Id == id);
        }
    }
}
