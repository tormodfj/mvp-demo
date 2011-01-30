using System;
using System.Collections.Generic;

namespace MvpDemoApplication
{
	public class PhonebookPresenter
	{
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
			view.SaveButtonClicked += HandleSaveButtonClick;
		}

		private void InitializePresenter()
		{
			view.SuspendLayout();
			foreach (PhonebookEntry entry in model.Entries)
			{
				view.AddContact(entry.FirstName, entry.LastName, entry.PhoneNumber);
			}
			view.ResumeLayout();
		}

		private void HandleSaveButtonClick(object sender, EventArgs e)
		{
			try
			{
				model.Entries.Clear();
				foreach (PhonebookEntry entry in GetAllEntries())
				{
					model.Entries.Add(entry);
				}
				model.Save();

				view.ShowMessage("Save completed");
			}
			catch (ValidationException)
			{
				view.ShowMessage("Phone numbers can consist only of digits.");
			}
		}

		private IEnumerable<PhonebookEntry> GetAllEntries()
		{
			for (int i = 0; i < view.GetContactCount(); i++)
			{
				yield return new PhonebookEntry
				{
					FirstName = view.GetFirstName(i),
					LastName = view.GetLastName(i),
					PhoneNumber = view.GetPhoneNumber(i)
				};
			}
		}
	}
}
