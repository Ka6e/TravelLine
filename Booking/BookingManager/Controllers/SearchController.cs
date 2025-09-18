using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route( "api/search" )]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController( ISearchService searchService )
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<IActionResult> Search( [FromQuery] SearchRequesDTO searchRequesDTO )
    {
        List<SearchResponseDTO> result = await _searchService.Search( searchRequesDTO );

        if ( result.Count == 0 )
        {
            return NotFound();
        }

        return Ok( result );
    }
}
