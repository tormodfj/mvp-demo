using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MvpDemoApplication
{
	public class PhonebookPresenter
	{
		private const string connectionString = @"Data Source = Database.sdf";

		private IPhonebookModel model;

		private IPhonebookView view;

		public PhonebookPresenter(IPhonebookModel model, IPhonebookView view)
		{
			this.model = model;
			this.view = view;

			SubscribeToEvents();
			InitializePresenter();
		}

		private void SubscribeToEvents()
		{
			view.SaveButtonClicked += SaveButton_Click;
		}

		private void InitializePresenter()
		{
			view.SuspendLayout();
			using (SqlCeConnection connection = new SqlCeConnection(connectionString))
			{
				connection.Open();

				using (SqlCeCommand getAllPersons = connection.CreateCommand())
				{
					getAllPersons.CommandText = @"SELECT FirstName, LastName, PhoneNumber FROM Persons";

					using (SqlCeDataReader reader = getAllPersons.ExecuteReader())
					{
						while (reader.Read())
						{
							view.AddContact(
								reader.GetString(0),
								reader.GetString(1),
								reader.GetString(2));
						}
					}
				}
			}
			view.ResumeLayout();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			for(int i = 0; i < view.GetContactCount(); i++)
			{
				string phoneNumber = view.GetPhoneNumber(i);
				if (!Regex.IsMatch(phoneNumber, @"^\d*$"))
				{
					view.ShowMessage("Phone numbers can consist only of digits.");
					return;
				}
			}

			using (SqlCeConnection connection = new SqlCeConnection(connectionString))
			{
				connection.Open();

				using (SqlCeCommand deleteAllPersons = connection.CreateCommand())
				{
					deleteAllPersons.CommandText = @"DELETE FROM Persons";
					deleteAllPersons.ExecuteNonQuery();
				}

				for(int i = 0; i < view.GetContactCount(); i++)
				{
					using (SqlCeCommand insertPerson = connection.CreateCommand())
					{
						insertPerson.CommandText = @"INSERT INTO Persons (FirstName, LastName, PhoneNumber) VALUES (@firstName, @lastName, @phoneNumber)";
						insertPerson.Parameters.Add("@firstName", SqlDbType.NVarChar, 100).Value = view.GetFirstName(i);
						insertPerson.Parameters.Add("@lastName", SqlDbType.NVarChar, 100).Value = view.GetLastName(i);
						insertPerson.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 20).Value = view.GetPhoneNumber(i);
						insertPerson.Prepare();
						insertPerson.ExecuteNonQuery();
					}
				}

				view.ShowMessage("Save completed");
			}
		}
	}
}
