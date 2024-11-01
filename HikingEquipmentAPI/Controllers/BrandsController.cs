using HikingEquipment.Services;
using HikingEquipment.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly HikingEquipmentContext _context;

    public BrandsController(HikingEquipmentContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
    {
        return await _context.Brands.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Brand>> GetBrand(int id)
    {
        var brand = await _context.Brands.FindAsync(id);

        if (brand == null)
        {
            return NotFound();
        }

        return brand;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostBrand([FromBody] Brand brand)
    {
        if (brand == null)
        {
            return BadRequest();
        }

        // Do not set brand id, let it be generated by the database
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBrand), new { id = brand.BrandId }, brand);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBrand(int id, [FromBody] Brand brand)
    {
        if (id != brand.BrandId)
        {
            return BadRequest();
        }

        if (brand == null || string.IsNullOrWhiteSpace(brand.Name))
        {
            return BadRequest("Brand name is required.");
        }

        _context.Entry(brand).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BrandExists(id))
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
    public async Task<IActionResult> DeleteBrand(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BrandExists(int id)
    {
        return _context.Brands.Any(e => e.BrandId == id);
    }
}
