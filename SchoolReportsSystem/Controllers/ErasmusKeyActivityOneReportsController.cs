using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolReportsSystem.Data;
using SchoolReportsSystem.Models;

namespace SchoolReportsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErasmusKeyActivityOneReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ErasmusKeyActivityOneReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ErasmusKeyActivityOneReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErasmusKeyActivityOneReport>>> GetErasmusKeyActivityOneReports()
        {
            return await _context.ErasmusKeyActivityOneReports.ToListAsync();
        }

        // GET: api/ErasmusKeyActivityOneReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErasmusKeyActivityOneReport>> GetErasmusKeyActivityOneReport(int id)
        {
            var erasmusKeyActivityOneReport = await _context.ErasmusKeyActivityOneReports.FindAsync(id);

            if (erasmusKeyActivityOneReport == null)
            {
                return NotFound();
            }

            return erasmusKeyActivityOneReport;
        }

        // PUT: api/ErasmusKeyActivityOneReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErasmusKeyActivityOneReport(int id, ErasmusKeyActivityOneReport erasmusKeyActivityOneReport)
        {
            if (id != erasmusKeyActivityOneReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(erasmusKeyActivityOneReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErasmusKeyActivityOneReportExists(id))
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

        // POST: api/ErasmusKeyActivityOneReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErasmusKeyActivityOneReport>> PostErasmusKeyActivityOneReport(ErasmusKeyActivityOneReport erasmusKeyActivityOneReport)
        {
            _context.ErasmusKeyActivityOneReports.Add(erasmusKeyActivityOneReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErasmusKeyActivityOneReport", new { id = erasmusKeyActivityOneReport.Id }, erasmusKeyActivityOneReport);
        }

        // DELETE: api/ErasmusKeyActivityOneReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErasmusKeyActivityOneReport(int id)
        {
            var erasmusKeyActivityOneReport = await _context.ErasmusKeyActivityOneReports.FindAsync(id);
            if (erasmusKeyActivityOneReport == null)
            {
                return NotFound();
            }

            _context.ErasmusKeyActivityOneReports.Remove(erasmusKeyActivityOneReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErasmusKeyActivityOneReportExists(int id)
        {
            return _context.ErasmusKeyActivityOneReports.Any(e => e.Id == id);
        }
    }
}
