using Microsoft.AspNetCore.Mvc;
using SensorDataLib;


namespace Sensor_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly SensorDataRepository _repository;

        public SensorDataController(SensorDataRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<SensorDataController>
        [HttpGet]
        public IEnumerable<SensorData> GetAll()
        {
            return _repository.GetAll();
        }


        // POST api/<SensorDataController>
        [HttpPost]
        public SensorData Post([FromBody] SensorData value)
        {
            return _repository.Add(value);
        }
    }
}
