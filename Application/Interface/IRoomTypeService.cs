using Application.DTO;

namespace Application.Interface;
public interface IRoomTypeService
{
    public Task<int> Create( RoomTypeRequestDTO roomType);
    public Task Update(int id, RoomTypeUpdate roomType );
    public Task<RoomTypeDTO?> GetById( int id );
    public Task<List<RoomTypeDTO>> GetAll();
    public Task Delete( int id );
    public Task AddServices( int roomId, List<int> serviceIds );
    public Task AddAmenities( int roomId, List<int> amenitiesIds );
    public Task ActivateService ( int roomId, int serviceId );
    public Task DisactivateService ( int roomId, int serviceId );
    public Task ActivateAmenity ( int roomId, int amenityId );
    public Task DisactivateAmenity ( int roomId, int amenityId );
}
