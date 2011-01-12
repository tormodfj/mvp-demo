using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text.RegularExpressions;

namespace MvpDemoApplication
{
	public class PhonebookModel : IPhonebookModel
	{
		private const string connectionString = @"Data Source = Database.sdf";

		private List<PhonebookEntry> entries;

		public IList<PhonebookEntry> Entries
		{
			get { return entries; }
		}

		public PhonebookModel()
		{
			entries = new List<PhonebookEntry>();

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
			if (entries.Any(e => !Regex.IsMatch(e.PhoneNumber, @"^\d*$")))
			{
				throw new ValidationException();
			}
		}

		private void GetExistingEntriesFromDatabase()
		{
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
							entries.Add(new PhonebookEntry
							{
								FirstName = reader.GetString(0),
								LastName = reader.GetString(1),
								PhoneNumber = reader.GetString(2)
							});
						}
					}
				}
			}
		}

		private void SaveAllEntriesToDatabase()
		{
			using (SqlCeConnection connection = new SqlCeConnection(connectionString))
			{
				connection.Open();

				using (SqlCeCommand deleteAllPersons = connection.CreateCommand())
				{
					deleteAllPersons.CommandText = @"DELETE FROM Persons";
					deleteAllPersons.ExecuteNonQuery();
				}

				foreach (PhonebookEntry entry in entries)
				{
					using (SqlCeCommand insertPerson = connection.CreateCommand())
					{
						insertPerson.CommandText = @"INSERT INTO Persons (FirstName, LastName, PhoneNumber) VALUES (@firstName, @lastName, @phoneNumber)";
						insertPerson.Parameters.Add("@firstName", SqlDbType.NVarChar, 100).Value = entry.FirstName;
						insertPerson.Parameters.Add("@lastName", SqlDbType.NVarChar, 100).Value = entry.LastName;
						insertPerson.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 20).Value = entry.PhoneNumber;
						insertPerson.Prepare();
						insertPerson.ExecuteNonQuery();
					}
				}
			}
		}
	}
}
