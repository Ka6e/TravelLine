using Application.DTO;

namespace Application.Interface;
public interface IRoomTypeService
{
    public Task<int> Create( RoomTypeDTO roomType);
    public Task Update(int id, RoomTypeRequestDTO roomType );
    public Task<RoomTypeDTO?> GetById( int id );
    public Task<List<RoomTypeDTO>> GetAll();
    public Task Delete( int id );
    public Task AddServices( int roomId, List<int> serviceIds );
    public Task AddAmenities( int roomId, List<int> amenitiesIds );
}
