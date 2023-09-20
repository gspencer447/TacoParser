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

            // Takes your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                return null;
            }

            double lat1 = double.Parse(cells[0]);

            double lon1 = double.Parse(cells[1]);

            string name1 = cells[2];

            Point point1 = new Point { Latitude = lat1, Longitude = lon1 };
            TacoBell tacoBell1 = new TacoBell()
            {
                Name = name1,
                Location = point1,
            };
            return tacoBell1;
        }
    }
}