namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            double lat1 = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            double lon1 = double.Parse(cells[1]);
            // grab the name from your array at index 2
            string name1 = cells[2];
            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            Point point1 = new Point { Latitude = lat1, Longitude = lon1 };
            TacoBell tacoBell1 = new TacoBell()
            {
                Name = name1,
                Location = point1,
            };


            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell1;
        }
    }
}