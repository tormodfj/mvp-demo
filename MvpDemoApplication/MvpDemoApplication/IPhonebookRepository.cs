using System.Collections.Generic;

namespace MvpDemoApplication
{
	public interface IPhonebookRepository
	{
		IList<PhonebookEntry> GetAllEntries();

		void DeleteAllEntries();
		
		void InsertEntries(IEnumerable<PhonebookEntry> entries);
	}
}
