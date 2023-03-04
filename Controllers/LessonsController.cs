﻿using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public LessonsController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Lessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetLessons()
        {
            var context = await _context.Lessons.Include(p => p.AcademicSubject).ToListAsync();
            var answer = _mapper.Map<List<Lesson>, List<LessonDTO>>(context);
            return answer;
        }

        // GET: api/Lessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<IEnumerable<LessonDTO>>>> GetLesson(int id)
        {
            List<List<LessonDTO>> timetable = new List<List<LessonDTO>>();
            for (int i = 1; i <= (id < 5 ? 5 : 6); i++)
            {
                var context = await _context.Lessons.Where(x => x.ClassId == id)
                                                    .Where(z => z.Day == i)
                                                    .OrderBy(y => y.Index)
                                                    .Include(p => p.AcademicSubject).ToListAsync();
                var answer = _mapper.Map<List<Lesson>, List<LessonDTO>>(context);
                timetable.Add(answer);
            }
            
  
            if (timetable[0].Count == 0)
            {
                return NotFound();
            }

            return timetable;
        }

        // PUT: api/Lessons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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

        // POST: api/Lessons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lesson>> PostLesson(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLesson", new { id = lesson.Id }, lesson);
        }

        // DELETE: api/Lessons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}