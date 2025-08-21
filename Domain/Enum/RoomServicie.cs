namespace Domain.Enum;

[Flags]
public enum RoomServicie
{
    None = 0,
    Breakfast = 1,
    Lunch = 2,
    Dinner = 4,
    Cleaning = 8,
    Laundry = 16,
    AirportPickup = 32,
    SpaAccess = 64,
    GymAccess = 128
}
