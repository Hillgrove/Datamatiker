
namespace Opgave1
{
    public class TrophiesRepository
    {
        private int _nextId = 1;
        private List<Trophy> _trophies = new List<Trophy>();

        // Returnerer en kopi af listen af alle Trophy objekter: Brug en copy constructor.
        // Get() skal give mulighed for at filtrere på Year.
        // Get() skal give mulighed for at sortere på Competition eller Year.
        public List<Trophy> Get(int? beforeYear = null, int? afterYear = null, int? exactYear = null, string? orderBy = null)
        {
            List<Trophy> trophies = new List<Trophy>(_trophies);

            if (beforeYear.HasValue)
            {
                trophies = trophies.Where(t => t.Year < beforeYear).ToList();
            }

            if (afterYear.HasValue)
            {
                trophies = trophies.Where(t => t.Year > afterYear).ToList();
            }

            if (exactYear.HasValue) {
                trophies = trophies.Where(t => t.Year == exactYear).ToList();
            }

            if (orderBy == "Competition")
            {
                trophies = trophies.OrderBy(t => t.Competition).ToList();
            }
            else if (orderBy == "Year")
            {
                trophies = trophies.OrderBy(t => t.Year).ToList();
            }

            return trophies;
        }

        // Returnerer Trophy objektet med det angivne id - eller null.
        public Trophy? GetById(int id)
        {
            
            return _trophies.Find(t => t.Id == id);
        }

        // Tilføj id til trophy objektet. Tilføjer trophy til listen. Returnerer Trophy objektet
        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();

            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        // Sletter Trophy objektet med det angivne id. Returnerer Trophy objektet - eller null.
        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                return null;
            }

            _trophies.Remove(trophy);
            return trophy;
        }

        // Trophy objektet med det angivne id opdateres med values.
        // Returnerer det opdaterede Trophy objekt - eller null.
        public Trophy? Update(int id, Trophy trophy)
        {
            Trophy? existingTrophy = GetById(id);
            if (existingTrophy == null)
            {
                return null;
            }

            trophy.Validate();

            existingTrophy.Competition = trophy.Competition;
            existingTrophy.Year = trophy.Year;

            return existingTrophy;
        }
    }
}
