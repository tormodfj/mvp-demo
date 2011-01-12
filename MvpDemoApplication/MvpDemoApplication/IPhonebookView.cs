using System.Windows.Forms;
using System;

namespace MvpDemoApplication
{
	public interface IPhonebookView
	{
		event EventHandler SaveButtonClicked;

		void SuspendLayout();

		void ResumeLayout();

		void AddContact(string firstName, string lastName, string phoneNumber);

		string GetFirstName(int index);

		string GetLastName(int index);

		string GetPhoneNumber(int index);

		int GetContactCount();

		void ShowMessage(string message);
	}
}
