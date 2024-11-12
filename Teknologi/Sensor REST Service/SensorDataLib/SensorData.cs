namespace SensorDataLib
{
    public class SensorData
    {
        public int Id { get; set; }
        public string SensorName { get; set; } = "Ikke angivet";
        public int Speed { get; set; }

        public SensorData()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Sensor: {SensorName}, Speed: {Speed}";
        }
    }
}
