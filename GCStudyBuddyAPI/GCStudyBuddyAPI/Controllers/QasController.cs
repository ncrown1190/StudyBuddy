using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCStudyBuddyAPI.Entities;
using GCStudyBuddyAPI.DTOs;

namespace GCStudyBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QasController : ControllerBase
    {
        private readonly GcstudyBuddyDbContext _context;

        public QasController(GcstudyBuddyDbContext context)
        {
            _context = context;
        }

        // GET: api/Qas
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Qa>>> GetQas()
        //{
        //    return await _context.Qas.ToListAsync();
        //}

        public async Task<ActionResult<IEnumerable<QaDTO>>> GetQas()
        {
            var questionAnswer = await _context.Qas.ToListAsync();

            var questionAnswerDTOs = questionAnswer.Select(question => new QaDTO
            {
                Id = question.Id,
                Question = question.Question,
                Answer = question.Answer,
            }).ToList();

            return Ok(questionAnswerDTOs);
        }

        // GET: api/Qas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qa>> GetQa(int id)
        {
            var questionAnswer = await _context.Qas
                .Where(q => q.Id == id)
                .Select(q => new QaDTO
                {
                    Id = q.Id,
                    Question = q.Question,
                    Answer = q.Answer,
                }).ToListAsync();

            return Ok(questionAnswer);

            //var qa = await _context.Qas.FindAsync(id);

            //if (qa == null)
            //{
            //    return NotFound();
            //}

            //return qa;
        }

        // PUT: api/Qas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQa(int id, [FromBody] QaDTO questionAnswerDto)
        {

            var existing = await _context.Qas.FindAsync(id);

            if (existing == null)
            {
                return NotFound("No question exists with this Id");
            }

            existing.Question = questionAnswerDto.Question;
            existing.Answer = questionAnswerDto.Answer;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Qas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QaDTO>> AddQa(QaCreateDTO questionAnswerDto)
        {
            var newQuestionAnswer = new Qa
            {
                //Id = questionAnswerDto.Id,
                Question = questionAnswerDto.Question,
                Answer = questionAnswerDto.Answer,
            };

            _context.Qas.Add(newQuestionAnswer);
            await _context.SaveChangesAsync();

            var questionAnswerCreateDto = new QaDTO
            {
                Id = newQuestionAnswer.Id,
                Question = newQuestionAnswer.Question,
                Answer = newQuestionAnswer.Answer,
            };

            return CreatedAtAction(nameof(GetQas), new {id = newQuestionAnswer.Id }, questionAnswerCreateDto);
        }

        // DELETE: api/Qas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQa(int id)
        {
            var qa = await _context.Qas.FindAsync(id);
            if (qa == null)
            {
                return NotFound();
            }

            _context.Qas.Remove(qa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QaExists(int id)
        {
            return _context.Qas.Any(e => e.Id == id);
        }
    }
}
