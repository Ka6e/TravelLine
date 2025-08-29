using Application.DTO;
using Application.Interface;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route( "api/amenities" )]
public class AmenitiesController : ControllerBase
{
    private readonly IAmenityService _amenityService;
    private readonly IUnitOfWork _unitOfWork;
    public AmenitiesController( IAmenityService amenityService, IUnitOfWork unitOfWork )
    {
        _amenityService = amenityService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAmenities()
    {
        List<AmenityDTO> amenityDTOs = await _amenityService.GetAll();
        if ( amenityDTOs.Count == 0 )
        {
            return NoContent();
        }

        return Ok( amenityDTOs );
    }

    [HttpGet( "{id}" )]
    public async Task<IActionResult> GetAmenity( int id )
    {
        AmenityDTO amenityDTO = await _amenityService.GetById( id );
        if ( amenityDTO == null )
        {
            return NotFound();
        }
        return Ok( amenityDTO );
    }

    [HttpPost]
    public async Task<IActionResult> CreateAmenity( [FromBody] AmenityDTO amenityDTO )
    {
        int newId = await _amenityService.Create( amenityDTO );
        await _unitOfWork.CommitAsync();

        return CreatedAtAction( nameof( CreateAmenity ), new { id = newId }, newId );
    }

    [HttpPatch( "{id}/disactivate" )]
    public async Task<IActionResult> DisactivateAmenity( int id )
    {
        try
        {
            await _amenityService.Disactivate( id );
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPatch( "{id}/activate" )]
    public async Task<IActionResult> ActivateAmenity( int id )
    {
        try
        {
            await _amenityService.Activate( id );
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateAmenity( int id, AmenityDTO amenityDTO )
    {
        try
        {
            await _amenityService.Update( id, amenityDTO );
            await _unitOfWork.CommitAsync();
            return Ok();

        }
        catch ( KeyNotFoundException ex )
        {
            return BadRequest( ex.Message );
        }
    }
}
