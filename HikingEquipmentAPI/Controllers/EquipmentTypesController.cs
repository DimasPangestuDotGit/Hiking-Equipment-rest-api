using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HikingEquipment.Services;
using HikingEquipment.Services.Models;

namespace HikingEquipmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypesController : ControllerBase
    {
        private readonly HikingEquipmentContext _context;

        public EquipmentTypesController(HikingEquipmentContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentType>>> GetEquipmentTypes()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentType>> GetEquipmentType(int id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);

            if (equipmentType == null)
            {
                return NotFound();
            }

            return equipmentType;
        }
        
        [HttpPost]
        public async Task<ActionResult<EquipmentType>> PostEquipmentType(EquipmentType equipmentType)
        {
            _context.EquipmentTypes.Add(equipmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentType", new { id = equipmentType.EquipmentTypeId }, equipmentType);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentType(int id, EquipmentType equipmentType)
        {
            if (id != equipmentType.EquipmentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(equipmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentTypeExists(id))
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
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentType(int id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return NotFound();
            }

            _context.EquipmentTypes.Remove(equipmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentTypeExists(int id)
        {
            return _context.EquipmentTypes.Any(e => e.EquipmentTypeId == id);
        }
    }
}
