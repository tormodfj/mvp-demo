using System.Collections.Generic;

namespace MvpDemoApplication
{
	public interface IPhonebookModel
	{
		IList<PhonebookEntry> Entries { get; }

		void Save();
	}
}
