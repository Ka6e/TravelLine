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
                throw new ArgumentException( "Invalid car number" + number );
            }
            Number = number;
            Color = color;
            BodyType = body;
            Engine = engine;
            Transmission = transmission;
        }

        public int MaxSpeed()
        {
            double adjustmentCoefficient = 0.106;
            double maxSpeed = ( Engine.MaxRPM * Engine.HorsePower / BodyType.Weight ) * adjustmentCoefficient;
            if ( maxSpeed < 0 )
            {
                throw new InvalidOperationException( "Calculated max speed is negative, which is invalid." );
            }
            return ( int )Math.Round( maxSpeed );
        }

        public override string ToString()
        {
            return $"Number: {Number}\n" +
                $"Color: [{Color.ToString().ToLower()}]{Color}[/]" +
                $"BodyType: {BodyType.ToString()}" +
                $"Engine: {Engine.ToString()}" +
                $"Transmission: {Transmission.ToString()}";
        }

        private bool IsValidNumber( string number )
        {
            Regex regex = new Regex( @"$[0-9][A-Z]{3}[0-9]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase );
            if ( regex.IsMatch( number ) )
            {
                return true;
            }
            return false;
        }
    }
}
