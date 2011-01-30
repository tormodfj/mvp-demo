using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;

namespace MvpDemoApplication
{
	public class PhonebookRepository : IPhonebookRepository
	{
		private const string ConnectionString = @"Data Source = Database.sdf";

		private const string GetAllEntriesQuery = @"SELECT FirstName, LastName, PhoneNumber FROM Persons";

		private const string DeleteAllEntriesQuery = @"DELETE FROM Persons";

		private const string InsertEntryQuery = @"INSERT INTO Persons (FirstName, LastName, PhoneNumber) VALUES (@firstName, @lastName, @phoneNumber)";

		public IList<PhonebookEntry> GetAllEntries()
		{
			return GetAllEntriesInternal().ToList();
		}

		public void DeleteAllEntries()
		{
			DeleteAllEntriesInternal();
		}

		public void InsertEntries(IEnumerable<PhonebookEntry> entries)
		{
			InsertEntriesInternal(entries);
		}

		private IEnumerable<PhonebookEntry> GetAllEntriesInternal()
		{
			using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
			{
				connection.Open();

				using (SqlCeCommand getAllEntries = connection.CreateCommand())
				{
					getAllEntries.CommandText = GetAllEntriesQuery;

					using (SqlCeDataReader reader = getAllEntries.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return new PhonebookEntry
							{
								FirstName = reader.GetString(0),
								LastName = reader.GetString(1),
								PhoneNumber = reader.GetString(2)
							};
						}
					}
				}
			}
		}

		private void DeleteAllEntriesInternal()
		{
			using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
			{
				connection.Open();

				using (SqlCeCommand deleteAllEntries = connection.CreateCommand())
				{
					deleteAllEntries.CommandText = DeleteAllEntriesQuery;
					deleteAllEntries.ExecuteNonQuery();
				}
			}
		}

		private void InsertEntriesInternal(IEnumerable<PhonebookEntry> entries)
		{
			using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
			{
				connection.Open();

				foreach (PhonebookEntry entry in entries)
				{
					using (SqlCeCommand insertPerson = connection.CreateCommand())
					{
						insertPerson.CommandText = InsertEntryQuery;
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
