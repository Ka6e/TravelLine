using Application.DTO;

namespace Application.Interface;
public interface ISearchService
{
    public Task<List<SearchResponseDTO>> Search( SearchRequesDTO searchRequesDTO );
}
