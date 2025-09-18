using Application.DTO;

namespace Application.Interface;
public interface IPropertySevice
{
    public Task<int> Create( PropertyDTO property );
    public Task Update( int id, PropertyDTO property );
    public Task<PropertyDTO?> GetById( int id );
    public Task<List<RoomTypeDTO>> GetRoomTypesProperty( int id );
    public Task<List<PropertyDTO>> GetAll();
    public Task Delete( int id );
}
