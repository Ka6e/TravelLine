using Domain.Entities;

namespace Domain.Repositories;
public interface IRoomTypeRepository
{
    public void Create( RoomType property );
    public Task<List<RoomType>> GetAll();
    public Task<RoomType?> GetById( int id );
    public void Delete( RoomType property );
}
