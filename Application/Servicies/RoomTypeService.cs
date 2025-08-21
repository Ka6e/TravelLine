using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure;

namespace Application.Servicies;
public class RoomTypeService : IRoomTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoomTypeRepository _roomTypeRepository;
    public RoomTypeService( IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork )
    {
        _roomTypeRepository = roomTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Create( RoomTypeDTO roomType )
    {
        RoomType room = Mapper.Mapper.ToRoomType( roomType );
        _roomTypeRepository.Create( room );
        await _unitOfWork.CommitAsync();

        return room.Id;
    }

    public async Task Delete( int id )
    {
        RoomType roomType = await _roomTypeRepository.GetById( id );
        if ( roomType == null )
        {
            throw new KeyNotFoundException( $"RoomType with {nameof( id )} {id} not found." );
        }
        _roomTypeRepository.Delete( roomType );
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<RoomTypeDTO>> GetAll()
    {
        List<RoomType> roomTypeDTOs = await _roomTypeRepository.GetAll();
        var filtered = roomTypeDTOs.Where(rt => rt.IsDeleted == false );

        return filtered.Select( r => Mapper.Mapper.ToRoomTypeDTO( r ) ).ToList();
    }

    public async Task<RoomTypeDTO?> GetById( int id )
    {
        RoomType roomType = await _roomTypeRepository.GetById( id );
        return roomType == null ? null : Mapper.Mapper.ToRoomTypeDTO( roomType );
    }

    public async Task Update( int id, RoomTypeRequestDTO roomTypeDTO )
    {
        RoomType roomType = await _roomTypeRepository.GetById( id );
        if ( roomType == null )
        {
            throw new KeyNotFoundException( $"RoomType with id {id} not found." );
        }

        UpdateRoom( roomType, roomTypeDTO );
        await _unitOfWork.CommitAsync();
    }

    private void UpdateRoom( RoomType roomType, RoomTypeRequestDTO roomTypeDTO )
    {
        roomType.SetName( roomTypeDTO.Name );
        roomType.SetDailyPrice( roomTypeDTO.DailyPrice );
        roomType.SetCapacity( roomTypeDTO.MinPersonCount, roomTypeDTO.MaxPersonCount );
        roomType.SetServicies( roomTypeDTO.Servicies );
        roomType.SetAmenities( roomTypeDTO.Amenities );
    }
}