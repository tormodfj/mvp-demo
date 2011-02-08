using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MvpDemoApplication.Tests.PhonebookPresenterSpecs
{
	[TestClass]
	public class When_the_Save_button_is_clicked : Shared
	{
		public When_the_Save_button_is_clicked() : base()
		{
			view.Raise(v => v.SaveButtonClicked += null, EventArgs.Empty);
		}

		[TestMethod]
		public void Should_clear_existing_contacts_from_model()
		{
			modelEntries.Verify(e => e.Clear());
		}

		[TestMethod]
		public void Should_add_two_entries_to_model()
		{
			modelEntries.Verify(e => e.Add(It.IsAny<PhonebookEntry>()), Times.Exactly(2));
		}

		[TestMethod]
		public void Should_save_model()
		{
			model.Verify(m => m.Save());
		}
	}

	public abstract class Shared
	{
		protected Mock<IPhonebookModel> model;
		protected Mock<IList<PhonebookEntry>> modelEntries;
		protected Mock<IPhonebookView> view;
		protected PhonebookPresenter presenter;

		public Shared()
		{
			model = new Mock<IPhonebookModel>();
			modelEntries = new Mock<IList<PhonebookEntry>>();
			view = new Mock<IPhonebookView>();
	
			SetupMocks();

			presenter = new PhonebookPresenter(model.Object, view.Object);
		}

		private void SetupMocks()
		{
			view.Setup(v => v.GetContactCount()).Returns(2);
			view.Setup(v => v.GetFirstName(It.IsAny<int>())).Returns("John");
			view.Setup(v => v.GetLastName(It.IsAny<int>())).Returns("Doe");
			view.Setup(v => v.GetPhoneNumber(It.IsAny<int>())).Returns("12345678");

			model.SetupGet(m => m.Entries).Returns(modelEntries.Object);

			modelEntries.Setup(e => e.GetEnumerator()).Returns(Enumerable.Empty<PhonebookEntry>().GetEnumerator());
		}
	}
}
