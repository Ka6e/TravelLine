namespace Domain.Enum;

[Flags]
public enum Amenity
{
    None = 0,
    Wifi = 1,
    AirConditioning = 2,
    TV = 4,
    MiniBar = 8,
    Balcony = 16,
    Kitchen = 32,
    PetFriendly = 64,
    Parking = 128,
    PoolAccess = 256
}
