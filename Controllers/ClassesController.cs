﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using School.ViewModels;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public ClassesController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetClasses()
        {
            var context = await _context.Classes.Include(x => x.ClassTeacher).ToListAsync();
            var classes = _mapper.Map<List<Class>, List<ClassDTO>>(context);
            return classes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDTO>> GetClass(int id)
        {
            var context = await _context.Classes.Include(x => x.ClassTeacher).FirstOrDefaultAsync(p => p.Id == id);
            var @class = _mapper.Map<Class, ClassDTO>(context);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, Class @class)
        {
            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
