using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MvpDemoApplication
{
	public partial class Phonebook : Form
	{
		private const string connectionString = @"Data Source = Database.sdf";

		public Phonebook()
		{
			InitializeComponent();

			SuspendLayout();
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
							contactsGrid.Rows.Add(
								reader.GetString(0),
								reader.GetString(1),
								reader.GetString(2));
						}
					}
				}
			}
			ResumeLayout();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow contactRow in contactsGrid.Rows)
			{
				if (contactRow.IsNewRow) continue;

				if(!Regex.IsMatch(contactRow.Cells[2].Value as string, @"^\d*$"))
				{
					MessageBox.Show("Phone numbers can consist only of digits.");
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

				foreach (DataGridViewRow contactRow in contactsGrid.Rows)
				{
					if (contactRow.IsNewRow) continue;

					using (SqlCeCommand insertPerson = connection.CreateCommand())
					{
						insertPerson.CommandText = @"INSERT INTO Persons (FirstName, LastName, PhoneNumber) VALUES (@firstName, @lastName, @phoneNumber)";
						insertPerson.Parameters.Add("@firstName", SqlDbType.NVarChar, 100).Value = contactRow.Cells[0].Value;
						insertPerson.Parameters.Add("@lastName", SqlDbType.NVarChar, 100).Value = contactRow.Cells[1].Value;
						insertPerson.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 20).Value = contactRow.Cells[2].Value;
						insertPerson.Prepare();
						insertPerson.ExecuteNonQuery();
					}
				}

				MessageBox.Show("Save completed");
			}
		}
	}
}
