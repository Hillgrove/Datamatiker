namespace SensorDataLib
{
    public class SensorDataRepository
    {
        private List<SensorData> _sensorData;
        private int _nextId;

        public SensorDataRepository()
        {
            _sensorData = new List<SensorData>();
            _nextId = 1;
        }

        public List<SensorData> GetAll()
        {
            return new List<SensorData>(_sensorData);

        }

        public SensorData Add(SensorData sensorData)
        {
            sensorData.Id = _nextId++;
            _sensorData.Add(sensorData);
            return sensorData;
        }
    }
}
