namespace MvpDemoApplication
{
	public interface IPhonebookEntryValidator
	{
		string ValidationRule { get; }

		bool Validate(PhonebookEntry entry);
	}
}
