using System.Collections.Generic;
using System.Linq;

namespace MvpDemoApplication
{
	public class PhonebookModel : IPhonebookModel
	{
		private IPhonebookRepository repository;

		private IPhonebookEntryValidator validator;

		private List<PhonebookEntry> entries;

		public IList<PhonebookEntry> Entries
		{
			get { return entries; }
		}

		public PhonebookModel(IPhonebookRepository repository, IPhonebookEntryValidator validator)
		{
			this.entries = new List<PhonebookEntry>();
			this.repository = repository;
			this.validator = validator;

			InitializeModel();
		}

		public void Save()
		{
			ValidatePhoneNumbers();
			SaveAllEntriesToDatabase();
		}

		private void InitializeModel()
		{
			GetExistingEntriesFromDatabase();
		}

		private void ValidatePhoneNumbers()
		{
			if(!entries.All(e => validator.Validate(e)))
			{
				throw new ValidationException(validator.ValidationRule);
			}
		}

		private void GetExistingEntriesFromDatabase()
		{
			IList<PhonebookEntry> allEntries = repository.GetAllEntries();
			entries.AddRange(allEntries);
		}

		private void SaveAllEntriesToDatabase()
		{
			repository.DeleteAllEntries();
			repository.InsertEntries(entries);
		}
	}
}
