using System.Text.RegularExpressions;

namespace MvpDemoApplication
{
	public class PhonebookEntryValidator : IPhonebookEntryValidator
	{
		private const string DigitsOnlyPattern = @"^\d+$";

		private const string Rule = @"Phone numbers can contain digits only.";

		public string ValidationRule
		{
			get { return Rule; }
		}

		public bool Validate(PhonebookEntry entry)
		{
			return Regex.IsMatch(entry.PhoneNumber, DigitsOnlyPattern);
		}
	}
}
