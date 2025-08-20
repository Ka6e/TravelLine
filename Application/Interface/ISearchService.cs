using Application.DTO;

namespace Application.Interface;
public interface ISearchService
{
    Task<List<SearchResponseDTO>> Search(SearchRequesDTO searchRequesDTO);
}
