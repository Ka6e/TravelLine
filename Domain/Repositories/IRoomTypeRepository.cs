using Domain.Entities;

namespace Domain.Repositories;
public interface IRoomTypeRepository
{
    public void Create( RoomType property );
    public Task<List<RoomType>> GetAll();
    public Task<RoomType?> GetById( int id );
    public void Delete( RoomType property );
    //public Task AddService( int roomId, int serviceId );
    //public Task AddAmenity( int roomId, int serviceId );
}
