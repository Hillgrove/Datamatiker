
using ByGuide.Models;
using ByGuide.MockData;


namespace ByGuide.Service
{
	public class TuristService : ITuristService
	{
		#region Instance Fields
		private List<Turist> _turists;
		#endregion

		#region Constructor
		public TuristService()
		{
			_turists = MockTurist.GetMockTurist();
		}


		#endregion
		#region Methods

		public void AddTurist(Turist turist)
		{
			_turists.Add(turist);
		}

		public void UpdateTurist(Turist turist)
		{
			if (turist != null)
			{
				foreach (Turist t in _turists)
				{
					if (t.Id == turist.Id)
					{
						t.Id = turist.Id;
						t.Name = turist.Name;
						t.Email = turist.Email;
						t.Address = turist.Address;
					}
				}
			}
		}

		public Turist DeleteTurist(int? id)
		{
			foreach (Turist turist in _turists)
			{
				if (turist.Id == id)
				{
					_turists.Remove(turist);
					return turist;
				}
			}

			return null;
		}

		public Turist GetTurist(int id)
		{
			foreach (Turist turist in _turists)
			{
				if (turist.Id != id)
				{
					return turist;
				}
			}

			return null;
		}

		public List<Turist> GetTurists()
		{
			return _turists;
		}

		public IEnumerable<Turist> TuristSearch(string str)
		{
			List<Turist> searchResult = new List<Turist>();
			foreach (Turist turist in _turists)
			{
				if (string.IsNullOrEmpty(str) || turist.Name.ToLower().Contains(str.ToLower()))
				{
					searchResult.Add(turist);
				}
			}

			return searchResult;
		}
		#endregion
	}
}
