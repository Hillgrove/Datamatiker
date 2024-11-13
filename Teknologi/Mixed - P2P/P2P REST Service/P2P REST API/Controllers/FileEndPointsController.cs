using Microsoft.AspNetCore.Mvc;
using P2PLib;
using P2PLib.Models;


namespace P2P_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileEndPointsController : ControllerBase
    {
        private readonly FileRepository _repository;

        public FileEndPointsController(FileRepository repository)
        {
            _repository = repository;
        }

        // (Optional) Get all filenames, returns a list of strings as a JSON list/array.
        // GET: api/<FileEndPointsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFilenames()
        {
            return Ok(_repository.GetAllFilenames());
        }

        // Get all peers for a specific filename, returns a list of FileEndPoint objects serialized as JSON.
        // GET api/<FileEndPointsController>/myDocument.doc
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{filename}")]
        public ActionResult<IEnumerable<FileEndPoint>> GetByFilename(string filename)
        {
            return Ok(_repository.GetPeersByFileName(filename));
        }


        // Register(POST) a filename with FileEndPoint data.The filename should be in the URI, while the FileEndPoint data should be sent as JSON in the body.
        // POST api/<FileEndPointsController>/myDocument.doc
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("{filename}")]
        public ActionResult Register([FromRoute] string filename, [FromBody] FileEndPoint fileEndPoint)
        {
            try
            {
                _repository.RegisterFilePeer(filename, fileEndPoint);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetByFilename), new { filename = filename }, fileEndPoint);
        }

        // (Optional) Delete a FileEndPoint from a filename’s associated list.The filename should be in the URI, while the FileEndPoint data should be sent as JSON in the body.
        // DELETE api/<FileEndPointsController>/myDocument.doc
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{filename}")]
        public ActionResult Delete([FromRoute] string filename, [FromBody] FileEndPoint fileEndPoint)
        {
            try
            {
                bool endPointDeleted = _repository.DeleteEndPoint(filename, fileEndPoint);
                return endPointDeleted 
                    ? Ok($"File endpoint for '{filename}' has been deleted.") 
                    : NotFound($"File endpoint '{filename}' not found or could not be deleted.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }   
        }
    }
}
