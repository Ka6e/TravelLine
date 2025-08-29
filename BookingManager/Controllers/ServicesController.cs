using Application.DTO;
using Application.Interface;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route("api/services")]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _service;
    private readonly IUnitOfWork _unitOfWork;

    public ServicesController( IServiceService service, IUnitOfWork unitOfWork )
    {
        _service = service;
        _unitOfWork = unitOfWork;
    }

    [HttpGet( "{id}" )]
    public async Task<IActionResult> GetService( int id )
    {
        ServiceDTO serviceDTO = await _service.GetById( id );
        if ( serviceDTO == null )
        {
            return NotFound();
        }
        return Ok( serviceDTO );
    }

    [HttpGet]
    public async Task<IActionResult> GetServicies()
    {
        List<ServiceDTO> serviceDTOs = await _service.GetAll();
        if ( serviceDTOs.Count == 0 )
        {
            return NoContent();
        }

        return Ok( serviceDTOs );
    }

    [HttpPost( "{id}" )]
    public async Task<IActionResult> CreateService( [FromBody] ServiceDTO serviceDTO )
    {
        int newId = await _service.Create( serviceDTO );
        await _unitOfWork.CommitAsync();

        return CreatedAtAction( nameof( CreateService ), new { id = newId }, newId );
    }

    [HttpPatch( "{id}/disactivate" )]
    public async Task<IActionResult> DisactivateService( int id )
    {
        try
        {
            await _service.Disactivate( id );
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPatch( "{id}/activate" )]
    public async Task<IActionResult> ActivateService( int id )
    {
        try
        {
            await _service.Activate( id );
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceDTO serviceDTO )
    {
        try
        {
            await _service.Update( id, serviceDTO );
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }
}

