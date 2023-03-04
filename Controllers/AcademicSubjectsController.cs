using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Models;
using Microsoft.EntityFrameworkCore;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicSubjectsController : ControllerBase
    {
        SchoolContext db;
        public AcademicSubjectsController(SchoolContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicSubject>>> Get()
        {
            return await db.AcademicSubjects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicSubject>> Get(int id)
        {
            AcademicSubject academicSubject = await db.AcademicSubjects.FirstOrDefaultAsync(x => x.Id == id);
            if (academicSubject == null)
            {
                return NotFound();
            }
            return new ObjectResult(academicSubject);
        }

        [HttpPost]
        public async Task<ActionResult<AcademicSubject>> Post(AcademicSubject academicSubject)
        {
            if (academicSubject == null)
            {
                return BadRequest();
            }

            db.AcademicSubjects.Add(academicSubject);
            await db.SaveChangesAsync();
            return Ok(academicSubject);
        }

        [HttpPut]
        public async Task<ActionResult<AcademicSubject>> Put(AcademicSubject academicSubject)
        {
            if (academicSubject == null)
            {
                return BadRequest();
            }
            if(!db.AcademicSubjects.Any(x => x.Id == academicSubject.Id))
            {
                return NotFound();
            }
            db.Update(academicSubject);
            await db.SaveChangesAsync();
            return Ok(academicSubject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademicSubject>> Delete(int id)
        {
            AcademicSubject academicSubject = db.AcademicSubjects.FirstOrDefault(x => x.Id == id);
            if (academicSubject == null)
            {
                return NotFound();
            }
            db.AcademicSubjects.Remove(academicSubject);
            await db.SaveChangesAsync();
            return Ok(academicSubject);
        }
    }
}