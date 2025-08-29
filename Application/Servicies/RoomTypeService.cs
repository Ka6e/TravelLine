using Application.DTO;
using Application.Extensions;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Servicies;
public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IAmenityRepository _amenityRepository;
    public RoomTypeService(
        IRoomTypeRepository roomTypeRepository,
        IServiceRepository serviceRepository,
        IAmenityRepository amenityRepository )
    {
        _roomTypeRepository = roomTypeRepository;
        _serviceRepository = serviceRepository;
        _amenityRepository = amenityRepository;
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
        var filtered = roomTypeDTOs.Where( rt => rt.IsDeleted == false );

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

    public async Task AddServices( int roomId, List<int> serviceIds )
    {
        RoomType roomType = await _roomTypeRepository.GetById( roomId );
        if ( roomType == null )
        {
            throw new KeyNotFoundException( $"RoomType with {roomId} not found." );
        }

        List<Service> services = await _serviceRepository.GetByIds( serviceIds );

        HashSet<int> foundIds = services.Select( s => s.Id ).ToHashSet();
        List<int> missingIds = serviceIds.Where( id => !foundIds.Contains( id ) ).ToList();
        if ( missingIds.Any() )
        {
            throw new KeyNotFoundException( $"Services with ids {string.Join( ", ", missingIds )} not found." );
        }

        foreach ( var service in services )
        {
            roomType.AddServicies( service );
        }
    }

    public async Task AddAmenities( int roomId, List<int> amenityIds )   
    {
        RoomType roomType = await _roomTypeRepository.GetById( roomId );
        if ( roomType == null )
        {
            throw new KeyNotFoundException( $"RoomType with {roomId} not found." );
        }

        List<Amenity> amenities = await _amenityRepository.GetByIds( amenityIds );

        HashSet<int> foundIds = amenities.Select( s => s.Id ).ToHashSet();
        List<int> missingIds = foundIds.Where( id => !foundIds.Contains( id ) ).ToList();
        if ( missingIds.Any() )
        {
            throw new KeyNotFoundException( $"Services with ids {string.Join( ", ", missingIds )} not found." );
        }

        foreach ( var amenity in amenities )
        {
            roomType.AddAmenity( amenity );
        }
    }
    private async Task UpdateRoom( RoomType roomType, RoomTypeRequestDTO roomTypeDTO )
    {
        roomType.SetName( roomTypeDTO.Name );
        roomType.SetDailyPrice( roomTypeDTO.DailyPrice );
        roomType.SetCapacity( roomTypeDTO.MinPersonCount, roomTypeDTO.MaxPersonCount );

        //List<Service> services = await _serviceRepository.GetById(roomTypeDTO.Servicies.Select(s => s);
        //List<Amenity> amenities = await _amenityRepository.GetAll();
        //тут разобраться

        roomType.SetServicies( roomTypeDTO.Servicies.Select( s => s.ConvertToEntity() ).ToList() );
        roomType.SetAmenities( roomTypeDTO.Amenities.Select( a => a.ConvertToEntity() ).ToList() );
    }
}