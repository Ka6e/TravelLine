using System.Text.RegularExpressions;
using CarFactory.Models.BodyType;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars
{
    public class Car : ICar
    {
        public string Number { get; }
        public Color Color { get; }
        public IBody BodyType { get; }
        public IEngine Engine { get; }
        public ITransmission Transmission { get; }

        public Car( string number, Color color, IBody body, IEngine engine, ITransmission transmission )
        {
            if ( !IsValidNumber( number ) )
            {
                throw new ArgumentException( "Invalid car number " + number );
            }
            Number = number;
            Color = color;
            BodyType = body;
            Engine = engine;
            Transmission = transmission;
        }

        public int MaxSpeed()
        {
            double wheelRadius = 0.34;
            double gearRatio = 4.0;
            double metersPerMinute = ( Engine.MaxRPM / gearRatio ) * ( 2 * Math.PI * wheelRadius );
            double kmPerHour = metersPerMinute * 60 / 1000;
            return ( int )Math.Round( kmPerHour );
        }

        private bool IsValidNumber( string number )
        {
            Regex regex = new Regex( @"^[A-Z][0-9]{3}[A-Z]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase );
            if ( regex.IsMatch( number ) )
            {
                return true;
            }
            return false;
        }
    }
}
