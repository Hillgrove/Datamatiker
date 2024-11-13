using P2PLib.Models;


namespace P2PLib
{
    public class FileRepository
    {
        private Dictionary<string, HashSet<FileEndPoint>> _filePeerMappings;

        public FileRepository()
        {
            _filePeerMappings = new Dictionary<string, HashSet<FileEndPoint>>();
        }

        //Get all peers for a specific filename, returns a list of FileEndPoint objects serialized as JSON.
        public List<FileEndPoint> GetPeersByFileName(string filename)
        {
            filename = filename.ToLower().Trim();

            if (string.IsNullOrEmpty(filename))
            {
                return new List<FileEndPoint>();
            }

            return _filePeerMappings.TryGetValue(filename, out var peers) ? peers.ToList() : new List<FileEndPoint>();
        }

        //Register(POST) a filename with FileEndPoint data.The filename should be in the URI, while the FileEndPoint data should be sent as JSON in the body.
        public void RegisterFilePeer(string filename, FileEndPoint fileEndPoint)
        {
            filename = filename.ToLower().Trim();

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("Filename cannot be null or empty", nameof(filename));
            }

            if (fileEndPoint == null)
            {
                throw new ArgumentNullException(nameof(fileEndPoint), "FileEndPoint cannot be null");
            }

            if (!_filePeerMappings.TryGetValue(filename, out var peers))
            {
                peers = new HashSet<FileEndPoint>();
                _filePeerMappings[filename] = peers;
            }

            peers.Add(fileEndPoint);
        }

        //(Optional) Delete a FileEndPoint from a filename’s associated list.The filename should be in the URI, while the FileEndPoint data should be sent as JSON in the body.
        public bool DeleteEndPoint(string filename, FileEndPoint fileEndPoint)
        {
            filename = filename.ToLower().Trim();

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("Filename cannot be null or empty", nameof(filename));
            }

            if (fileEndPoint == null)
            {
                throw new ArgumentNullException(nameof(fileEndPoint), "FileEndPoint cannot be null");
            }

            if (_filePeerMappings.TryGetValue(filename, out var peers))
            {
                bool removed = peers.Remove(fileEndPoint);

                if (removed && peers.Count == 0)
                {
                    _filePeerMappings.Remove(filename);
                }

                return removed;
            }

            // if filename does not exist in the dictionary
            return false;

        }

        //(Optional) Get all filenames, returns a list of strings as a JSON list/array.
        public List<string> GetAllFilenames()
        {
            return _filePeerMappings.Keys.ToList();
        }

    }
}
