using Application.DTO;
using Application.Extensions;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Servicies;
public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    public RoomTypeService( IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task<int> Create( RoomTypeDTO roomTypeDto )
    {
        RoomType room = roomTypeDto.ConvertToEntity();
        _roomTypeRepository.Create( room );

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
    }

    public async Task<List<RoomTypeDTO>> GetAll()
    {
        List<RoomType> roomTypeDTOs = await _roomTypeRepository.GetAll();
        var filtered = roomTypeDTOs.Where(rt => rt.IsDeleted == false );

        return filtered.Select( r => r.ConvertToDto() ).ToList();
    }

    public async Task<RoomTypeDTO?> GetById( int id )
    {
        RoomType roomType = await _roomTypeRepository.GetById( id );
        return roomType == null ? null : roomType.ConvertToDto();
    }

    public async Task Update( int id, RoomTypeRequestDTO roomTypeDTO )
    {
        RoomType roomType = await _roomTypeRepository.GetById( id );
        if ( roomType == null )
        {
            throw new KeyNotFoundException( $"RoomType with id {id} not found." );
        }
        UpdateRoom( roomType, roomTypeDTO );
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