using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class GuestExtensions
{
    public static Guest ConvertToEntity( this GuestDTO guestDTO)
    {
        return new Guest(
            guestDTO.FirstName,
            guestDTO.LastName,
            guestDTO.PhoneNumber,
            guestDTO.Email );
    }

    public static GuestDTO ConvertToDto( this Guest guest)
    {
        return new GuestDTO
        {
            FirstName = guest.FirstName,
            LastName = guest.LastName,
            PhoneNumber = guest.PhoneNumber,
            Email = guest.Email
        };
    }
}
