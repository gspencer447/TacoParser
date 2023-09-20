using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable trackable1 = null;
            ITrackable trackable2 = null;
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate()
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude,
                };

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate()

                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude,
                    };
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        trackable1 = locA;
                        trackable2 = locB;
                    }
                }
            }
            Console.WriteLine($"{trackable1.Name} and {trackable2.Name} are furthest from each other. They are {distance / 1609.344} miles away from each other.");          
        }
    }
}
