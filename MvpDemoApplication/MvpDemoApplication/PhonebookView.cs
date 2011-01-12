using System.Windows.Forms;
using System;

namespace MvpDemoApplication
{
	public partial class PhonebookView : Form, IPhonebookView
	{
		public event EventHandler SaveButtonClicked
		{
			add { saveButton.Click += value; }
			remove { saveButton.Click -= value; }
		}

		public PhonebookView()
		{
			InitializeComponent();
			PhonebookModel model = new PhonebookModel();
			PhonebookPresenter presenter = new PhonebookPresenter(model, this);
		}

		public void AddContact(string firstName, string lastName, string phoneNumber)
		{
			contactsGrid.Rows.Add(firstName, lastName, phoneNumber);
		}

		public string GetFirstName(int rowIndex)
		{
			return contactsGrid[firstNameColumn.Index, rowIndex].Value as string;
		}

		public string GetLastName(int rowIndex)
		{
			return contactsGrid[lastNameColumn.Index, rowIndex].Value as string;
		}

		public string GetPhoneNumber(int rowIndex)
		{
			return contactsGrid[phoneNumberColumn.Index, rowIndex].Value as string;
		}

		public int GetContactCount()
		{
			return contactsGrid.RowCount - 1; // do not include new "uncommitted" line
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(this, message);
		}
	}
}
