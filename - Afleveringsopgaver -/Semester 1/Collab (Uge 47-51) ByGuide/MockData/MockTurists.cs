using ByGuide.Models;
using ByGuide.MockData;
using Microsoft.Extensions.Hosting;

namespace ByGuide.MockData
{
	public class MockTurist
	{
		#region Static Fields
		private static List<Turist> _turists = new List<Turist>();
	
			#endregion

			#region Methods
			public static List<Turist> GetMockTurist()
			{
				return _turists;
			}
			#endregion
	}
}